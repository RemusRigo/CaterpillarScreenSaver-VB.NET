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

   ' This will capture the entire desktop, including all monitors, and return a bitmap of the specified bounds.
   Private Function CaptureScreen(bounds As Rectangle) As Bitmap
      Dim bmp As New Bitmap(bounds.Width, bounds.Height, Imaging.PixelFormat.Format32bppPArgb)
      Using g As Graphics = Graphics.FromImage(bmp)
         g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size)
      End Using
      Return bmp
   End Function

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

   Private Sub RunScreenSaver()
      Dim vSrc As Rectangle = SystemInformation.VirtualScreen
      Dim DeskSnap As Bitmap = Nothing
      Dim imgPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Remus RIGO\SnapDesktop\Desktop.png")
      Dim wallpaperPath As String = ""

      ' if ScreenSaver helper app is installed, use its Desktop ScreenShot path, else use the current wallpaper path from the registry
      If Not File.Exists(imgPath) Then
         Using key As RegistryKey = Registry.CurrentUser.OpenSubKey("Control Panel\Desktop")
            imgPath = CStr(key.GetValue("WallPaper"))
         End Using
      End If

      If File.Exists(imgPath) Then
         ' copy image to memory to avoid file locking issues
         Using fs As New FileStream(imgPath, FileMode.Open, FileAccess.Read)
            DeskSnap = New Bitmap(fs)
         End Using
      End If

      Dim frm As New frmSS(vSrc, DeskSnap)
      Application.Run(frm)
   End Sub

   Private Sub ShowSettings()
      Using frm As New frmCfg()
         frm.ShowDialog()
      End Using
   End Sub

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

   Private Sub ShowPreview(parentHandle As IntPtr)
      If parentHandle = IntPtr.Zero Then Return

      Dim rc As RECT

      If Not GetClientRect(parentHandle, rc) Then Return
      Dim sz As New Size(rc.Right - rc.Left, rc.Bottom - rc.Top)
      If sz.Width < 10 OrElse sz.Height < 10 Then Return

      'Dim sz As Size = Size.Empty

      ' The pane can still be 0x0 when we start: retry for up to ~5 seconds
      'For attempt As Integer = 1 To 50
      '   If GetClientRect(parentHandle, rc) Then
      '      sz = New Size(rc.Right - rc.Left, rc.Bottom - rc.Top)
      '      If sz.Width >= 10 AndAlso sz.Height >= 10 Then Exit For
      '   End If
      '   Threading.Thread.Sleep(100)
      'Next
      'If sz.Width < 10 OrElse sz.Height < 10 Then Return

      Using shot As Bitmap = CaptureScreen(Screen.PrimaryScreen.Bounds)
         Application.Run(New frmPreview(parentHandle, sz, shot))
      End Using
   End Sub

End Module
