'--------------------------------------------------------------------------------------------------
' Caterpillar Screensaver: frmPreview.vb: Preview form
'    © 2026 Remus Rigo
'       v1.0.20261011
'--------------------------------------------------------------------------------------------------

Imports CaterpillarSS.API

Public Class frmPreview
   Inherits Form

   Private Const WS_CHILD As Integer = &H40000000
   Private Const WS_POPUP As Integer = &H80000000
   Private Const WS_VISIBLE As Integer = &H10000000

   Private ReadOnly _parent As IntPtr
   Private ReadOnly _size As Size
   Private ReadOnly _img As Bitmap
   Private WithEvents _timer As New Timer With {.Interval = 250}

   '-----------------------------------------------------------------------------------------------
   ' frmPreview: constructor
   Public Sub New(parent As IntPtr, sz As Size, shot As Bitmap)
      InitializeComponent()
      _parent = parent
      _size = sz

      FormBorderStyle = FormBorderStyle.None
      ShowInTaskbar = False
      StartPosition = FormStartPosition.Manual
      BackColor = Color.Black
      DoubleBuffered = True

      _img = BuildPreviewImage(sz, shot)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Turn the form into a child window of the preview pane
   'Protected Overrides ReadOnly Property CreateParams As CreateParams
   '   Get
   '      Dim cp As CreateParams = MyBase.CreateParams
   '      'cp.Style = (cp.Style And Not WS_POPUP) Or WS_CHILD
   '      cp.Style = (cp.Style And Not WS_POPUP) Or WS_CHILD Or WS_VISIBLE
   '      cp.Parent = _parent
   '      cp.X = 0
   '      cp.Y = 0
   '      cp.Width = _size.Width
   '      cp.Height = _size.Height
   '      Return cp
   '   End Get
   'End Property

   '-----------------------------------------------------------------------------------------------
   ' BuildPreviewImage: create a bitmap of the caterpillar on a black background
   Private Function BuildPreviewImage(sz As Size, shot As Bitmap) As Bitmap
      Dim bmp As New Bitmap(sz.Width, sz.Height)
      Dim k As Single = sz.Width / CSng(shot.Width)
      Dim r As Single = Math.Max(3.0F, AppSettings.BodySize * k)
      Dim w As Single = sz.Width
      Dim h As Single = sz.Height

      Using g As Graphics = Graphics.FromImage(bmp)
         g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
         g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
         g.DrawImage(shot, 0, 0, sz.Width, sz.Height)

         ' Path: a gentle wave across the pane
         Dim pt As Func(Of Single, PointF) = Function(u As Single) New PointF(w * u, h * (0.5F + 0.15F * CSng(Math.Sin(u * 9.0F))))

         ' Eaten trail
         Dim t0 As Single = 0.15F
         Dim headT As Single = 0.62F
         Dim t As Single = t0
         While t <= headT
            Dim p As PointF = pt(t)
            g.FillEllipse(Brushes.Black, p.X - r * 1.2F, p.Y - r * 1.2F, r * 2.4F, r * 2.4F)
            t += 0.004F
         End While

         ' Body, tail first so the head ends up on top
         Const Count As Integer = 12
         Dim dt As Single = r * 1.15F / w
         For i As Integer = Count - 1 To 0 Step -1
            Dim p As PointF = pt(headT - i * dt)
            Dim rad As Single = r * (1.0F - 0.45F * i / (Count - 1))
            Dim fill As Color
            If i = 0 Then
               fill = AppSettings.Shade(AppSettings.BodyColor, 0.6F)
            ElseIf i Mod 2 = 0 Then
               fill = AppSettings.BodyColor
            Else
               fill = AppSettings.Shade(AppSettings.BodyColor, 1.25F)
            End If
            Using br As New SolidBrush(fill)
               g.FillEllipse(br, p.X - rad, p.Y - rad, rad * 2, rad * 2)
            End Using
         Next
      End Using
      Return bmp
   End Function

   '-----------------------------------------------------------------------------------------------
   ' frmPreview: onLoad
   Private Sub frmPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Dim style As Integer = GetWindowLong(Handle, -16)                       ' GWL_STYLE
      SetWindowLong(Handle, -16, (style And Not WS_POPUP) Or WS_CHILD Or WS_VISIBLE)
      SetParent(Handle, _parent)
      SetBounds(0, 0, _size.Width, _size.Height)
      _timer.Start()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' frmPreview: onShown
   Private Sub frmPreview_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
      SetWindowPos(Handle, IntPtr.Zero, 0, 0, 0, 0, &H43UI)   ' HWND_TOP, NOSIZE|NOMOVE|SHOWWINDOW
      Invalidate()
      Update()
   End Sub
   '-----------------------------------------------------------------------------------------------
   ' frmPreview: onFormClosed
   Private Sub frmPreview_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
      _timer.Stop()
      _img.Dispose()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' frmPreview: onPaint
   Protected Overrides Sub OnPaint(e As PaintEventArgs)
      e.Graphics.DrawImageUnscaled(_img, 0, 0)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' _timer: onTick
   ' Windows destroys the preview pane without telling us: poll for it and quit
   Private Sub _timer_Tick(sender As Object, e As EventArgs) Handles _timer.Tick
      If Not IsWindow(_parent) Then Close()
      Invalidate()
   End Sub

End Class