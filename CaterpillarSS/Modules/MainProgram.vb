'--------------------------------------------------------------------------------------------------
' Caterpillar Screensaver: MainProgram.vb: Main program
'    © 2026 Remus Rigo
'       v1.0.20261011
'--------------------------------------------------------------------------------------------------

Imports Microsoft.Win32
Imports System.IO

Imports CaterpillarSS.API

Module MainProgram

   Private Const GENERIC_ALL As UInteger = &H10000000UI

   '-----------------------------------------------------------------------------------------------
   ' Main()
   <STAThread>
   Sub Main(args As String())
      SetProcessDPIAware()
      AppSettings.Load()
      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)

      Dim mode As String = ""

      If args.Length > 0 Then mode = args(0).Trim().ToLower().Substring(0, 2)

      Select Case mode
         Case "/c"
            ShowSettings()
         Case "/p"
            ShowPreview(PreviewHandle(args))
         Case "/s"
            RunScreenSaver()
         Case Else
            RunScreenSaver()
      End Select
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' RunScreenSaver
   Private Sub RunScreenSaver()
      Dim vSrc As Rectangle = SystemInformation.VirtualScreen
      Dim DeskSnap As Bitmap = Nothing
      Dim imgPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Remus RIGO\SnapDesktop\Desktop.png")

      ' load ScreenSaver from the Desktop ScreenShot helper (SnapDesktop)
      If File.Exists(imgPath) Then
         ' copy image to memory to avoid file locking issues
         Try
            Using fs As New FileStream(imgPath, FileMode.Open, FileAccess.Read)
               DeskSnap = New Bitmap(fs)
            End Using
         Catch
            DeskSnap = Nothing
         End Try
      Else
         ' load Wallpaper
         Try
            Using key As RegistryKey = Registry.CurrentUser.OpenSubKey("Control Panel\Desktop")
               imgPath = If(key Is Nothing, "", Convert.ToString(key.GetValue("WallPaper")))
            End Using
         Catch
         End Try

         If File.Exists(imgPath) Then
            Try
               Using fs As New FileStream(imgPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                  Using loaded As New Bitmap(fs)
                     DeskSnap = FitToScreens(loaded, vSrc)    ' fit wallpaper on every monitor
                  End Using
               End Using
            Catch
               DeskSnap = Nothing
            End Try
         End If
      End If

      ' nothing usable: paint the virtual screen with solid desktop background color of the current Windows theme
      If DeskSnap Is Nothing Then
         DeskSnap = New Bitmap(vSrc.Width, vSrc.Height, Imaging.PixelFormat.Format24bppRgb)
         Using g As Graphics = Graphics.FromImage(DeskSnap)
            g.Clear(ThemeColor())
         End Using
      End If

      Dim frm As New frmSS(vSrc, DeskSnap)
      Application.Run(frm)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' ShowSettings
   Private Sub ShowSettings()
      Using frm As New frmCfg()
         frm.ShowDialog()
      End Using
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' PreviewHandle:
   ' Windows passes the preview window handle as "/p 1234" or "/p:1234"
   Private Function PreviewHandle(args As String()) As IntPtr
      Dim s As String = ""
      If args.Length > 1 Then
         s = args(1)                  ' "/p" "1234"
      ElseIf args.Length = 1 AndAlso args(0).Length > 3 Then
         s = args(0).Substring(3)     ' "/p:1234"
      End If

      Dim v As Long
      If Long.TryParse(s.Trim(), v) Then Return New IntPtr(v)
      Return IntPtr.Zero
   End Function

   '-----------------------------------------------------------------------------------------------
   ' ShowPreview
   Private Sub ShowPreview(parentHandle As IntPtr)
      If parentHandle = IntPtr.Zero Then Return

      Dim rc As RECT

      If Not GetClientRect(parentHandle, rc) Then Return
      Dim sz As New Size(rc.Right - rc.Left, rc.Bottom - rc.Top)
      If sz.Width < 10 OrElse sz.Height < 10 Then Return

      Using shot As Bitmap = CaptureScreen(Screen.PrimaryScreen.Bounds)
         Application.Run(New frmPreview(parentHandle, sz, shot))
      End Using
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' CaptureScreen
   ' This will capture the entire desktop, including all monitors, and return a bitmap of the specified bounds.
   Private Function CaptureScreen(bounds As Rectangle) As Bitmap
      Dim bmp As New Bitmap(bounds.Width, bounds.Height, Imaging.PixelFormat.Format32bppPArgb)
      Using g As Graphics = Graphics.FromImage(bmp)
         g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size)
      End Using
      Return bmp
   End Function

   '-----------------------------------------------------------------------------------------------
   ' CaptureDesktop
   Private Function CaptureDesktop(bounds As Rectangle) As Bitmap
      Dim original As IntPtr = GetThreadDesktop(GetCurrentThreadId())
      Dim hDefault As IntPtr = OpenDesktop("Default", 0, False, GENERIC_ALL)
      Dim switched As Boolean = False
      If hDefault <> IntPtr.Zero Then switched = SetThreadDesktop(hDefault)
      Try
         Return CaptureScreen(bounds)
      Finally
         If switched Then SetThreadDesktop(original)
         If hDefault <> IntPtr.Zero Then CloseDesktop(hDefault)
      End Try
   End Function

   '-----------------------------------------------------------------------------------------------
   ' FitToScreens
   ' Draws the image onto every monitor, scaled to fill it (centred, overflow cropped)
   Private Function FitToScreens(src As Image, virt As Rectangle) As Bitmap
      Dim bmp As New Bitmap(virt.Width, virt.Height, Imaging.PixelFormat.Format24bppRgb)
      Using g As Graphics = Graphics.FromImage(bmp)
         g.Clear(Color.Black)
         g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
         g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality

         For Each scr As Screen In Screen.AllScreens
            ' Monitor rectangle in bitmap coordinates (0,0 = top-left of the virtual screen)
            Dim dest As New Rectangle(scr.Bounds.X - virt.X, scr.Bounds.Y - virt.Y, scr.Bounds.Width, scr.Bounds.Height)

            ' Fill: scale so the image covers the monitor, then crop the overflow evenly
            Dim scale As Single = Math.Max(dest.Width / CSng(src.Width), dest.Height / CSng(src.Height))
            Dim cw As Single = dest.Width / scale
            Dim ch As Single = dest.Height / scale
            g.DrawImage(src, dest, (src.Width - cw) / 2, (src.Height - ch) / 2, cw, ch, GraphicsUnit.Pixel)
         Next
      End Using
      Return bmp
   End Function

   '-----------------------------------------------------------------------------------------------
   ' ThemeColor: get solid desktop background color of the current Windows theme
   Private Function ThemeColor() As Color
      Try
         Using key As RegistryKey = Registry.CurrentUser.OpenSubKey("Control Panel\Colors")
            Dim s As String = If(key Is Nothing, "", Convert.ToString(key.GetValue("Background")))
            Dim p As String() = s.Trim().Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
            If p.Length = 3 Then Return Color.FromArgb(CInt(p(0)), CInt(p(1)), CInt(p(2)))
         End Using
      Catch
      End Try
      Return SystemColors.Desktop
   End Function
End Module
