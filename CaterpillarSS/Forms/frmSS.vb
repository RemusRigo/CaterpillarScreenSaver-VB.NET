'--------------------------------------------------------------------------------------------------
' Caterpillar Screensaver: frmSS.vb: Main form
'    © 2026 Remus Rigo
'       v1.0.20261011
'--------------------------------------------------------------------------------------------------

Public Class frmSS

   Private ReadOnly _bounds As Rectangle
   Private ReadOnly _screenshot As Bitmap
   Private ReadOnly _screenRects As New List(Of Rectangle)
   Private _mouseStart As Point = Point.Empty

   ' Constants for the caterpillar animation
   Private Const SegmentCount As Integer = 16      ' number of segments in the caterpillar (shorter = more "wiggly", longer = smoother)
   Private ReadOnly SegmentSpacing As Single   ' pixels between segment centers (slim = less space, fat = more space)
   Private ReadOnly HeadRadius As Single      ' radius of the head segment (the rest of the body is scaled down from this)
   Private ReadOnly Speed As Single = 1.5F            ' pixels per tick: lower = slower
   Private ReadOnly _bodyColor As Color
   Private ReadOnly _rnd As New Random()
   Private WithEvents _timer As New Timer With {.Interval = 16}
   Private ReadOnly _segs(SegmentCount - 1) As PointF   ' _segs(0) = head
   Private _angle As Double
   Private _turn As Double

   ' The caterpillar "eats" the screen by drawing a hole in the screenshot bitmap.
   ' The hole is drawn as a filled circle with a radius of BiteRadius, and the Graphics object used to draw the hole is kept open for efficiency.
   Private ReadOnly BiteRadius As Single       ' hole size, a bit wider than the body
   Private _eatG As Graphics                   ' kept open: we draw on the screenshot every tick

   '-----------------------------------------------------------------------------------------------
   ' frmSS: constructor
   Public Sub New(bounds As Rectangle, screenshot As Bitmap)
      InitializeComponent()
      _bounds = bounds
      _screenshot = screenshot

      Speed = AppSettings.Speed
      HeadRadius = AppSettings.BodySize
      BiteRadius = HeadRadius + 2.0F
      SegmentSpacing = HeadRadius * 1.15F
      _bodyColor = AppSettings.BodyColor

      Me.FormBorderStyle = FormBorderStyle.None
      Me.StartPosition = FormStartPosition.Manual
      Me.BackColor = Color.Black
      Me.ShowInTaskbar = False
      Me.KeyPreview = True
      Me.DoubleBuffered = True
      Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer, True)
      Me.TopMost = True
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' frmSS: onPaint
   Protected Overrides Sub OnPaint(e As PaintEventArgs)
      If _screenshot Is Nothing Then Return
      Dim g As Graphics = e.Graphics
      g.DrawImage(_screenshot, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel)
      DrawCaterpillar(g)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' MoveCaterpillar: update the caterpillar's position and body segments
   Private Sub MoveCaterpillar()
      ' Wander: the turn rate drifts randomly but stays small, so the path is smooth
      _turn = Math.Max(-0.06, Math.Min(0.06, _turn * 0.96 + (_rnd.NextDouble() - 0.5) * 0.03))
      _angle += _turn

      Dim nx As Single = _segs(0).X + CSng(Math.Cos(_angle) * Speed)
      Dim ny As Single = _segs(0).Y + CSng(Math.Sin(_angle) * Speed)
      If IsOnScreen(nx, ny) Then
         _segs(0) = New PointF(nx, ny)
      Else
         _angle += 0.15          ' at an edge: turn on the spot until the way is clear
      End If

      ' Each segment is pulled toward the one in front, keeping a fixed spacing
      For i As Integer = 1 To SegmentCount - 1
         Dim dx As Single = _segs(i - 1).X - _segs(i).X
         Dim dy As Single = _segs(i - 1).Y - _segs(i).Y
         Dim d As Double = Math.Sqrt(dx * dx + dy * dy)
         If d > SegmentSpacing Then
            Dim k As Single = CSng((d - SegmentSpacing) / d)
            _segs(i) = New PointF(_segs(i).X + dx * k, _segs(i).Y + dy * k)
         End If
      Next
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' IsOnScreen: check if a point is inside any of the screen rectangles
   Private Function IsOnScreen(x As Single, y As Single) As Boolean
      For Each r As Rectangle In _screenRects
         If r.Contains(CInt(x), CInt(y)) Then Return True
      Next
      Return False
   End Function

   '-----------------------------------------------------------------------------------------------
   ' BodyBounds: compute the bounding rectangle of the caterpillar's body, with padding for the "bite" and eyes
   Private Function BodyBounds() As Rectangle
      Dim minX As Single = Single.MaxValue, minY As Single = Single.MaxValue
      Dim maxX As Single = Single.MinValue, maxY As Single = Single.MinValue

      For Each p As PointF In _segs
         minX = Math.Min(minX, p.X) : maxX = Math.Max(maxX, p.X)
         minY = Math.Min(minY, p.Y) : maxY = Math.Max(maxY, p.Y)
      Next

      Dim pad As Single = HeadRadius * 1.6F + 8 ' extra padding to account for the "bite" and the eyes
      Return Rectangle.FromLTRB(CInt(minX - pad), CInt(minY - pad), CInt(maxX + pad), CInt(maxY + pad))
   End Function

   '-----------------------------------------------------------------------------------------------
   ' DrawCaterpillar: draw the caterpillar on the given Graphics object
   Private Sub DrawCaterpillar(g As Graphics)
      g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

      ' Tail first, so the head ends up on top
      For i As Integer = SegmentCount - 1 To 0 Step -1
         Dim rad As Single = HeadRadius * (1.0F - 0.45F * i / (SegmentCount - 1))
         Dim p As PointF = _segs(i)
         Dim fill As Color

         If i = 0 Then
            fill = AppSettings.Shade(_bodyColor, 0.6F)
         ElseIf i Mod 2 = 0 Then
            fill = _bodyColor
         Else
            fill = AppSettings.Shade(_bodyColor, 1.25F)
         End If

         Using br As New SolidBrush(fill), pen As New Pen(AppSettings.Shade(_bodyColor, 0.35F), 1.5F)
            g.FillEllipse(br, p.X - rad, p.Y - rad, rad * 2, rad * 2)
            g.DrawEllipse(pen, p.X - rad, p.Y - rad, rad * 2, rad * 2)
         End Using
      Next

      ' Eyes
      Dim h As PointF = _segs(0)
      Dim fx As Single = CSng(Math.Cos(_angle)), fy As Single = CSng(Math.Sin(_angle))
      Dim er As Single = HeadRadius * 0.28F      ' eye (white) radius
      Dim pr As Single = er * 0.5F               ' pupil radius

      For Each side As Single In {-1.0F, 1.0F}
         Dim ex As Single = h.X + fx * HeadRadius * 0.45F - fy * side * HeadRadius * 0.45F
         Dim ey As Single = h.Y + fy * HeadRadius * 0.45F + fx * side * HeadRadius * 0.45F
         'g.FillEllipse(Brushes.White, ex - 3, ey - 3, 6, 6)
         'g.FillEllipse(Brushes.Black, ex + fx * 1.2F - 1.5F, ey + fy * 1.2F - 1.5F, 3, 3)
         g.FillEllipse(Brushes.White, ex - er, ey - er, er * 2, er * 2)
         Dim px As Single = ex + fx * er * 0.4F     ' pupil shifted toward the heading
         Dim py As Single = ey + fy * er * 0.4F
         g.FillEllipse(Brushes.Black, px - pr, py - pr, pr * 2, pr * 2)
      Next
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Eat: draw a "bite" in the screenshot at the head's position, with a slightly random size for a ragged edge
   Private Sub Eat()
      ' The bite is centred just ahead of the head, with a slightly random size for a ragged edge
      Dim mx As Single = _segs(0).X + CSng(Math.Cos(_angle)) * HeadRadius * 0.6F
      Dim my As Single = _segs(0).Y + CSng(Math.Sin(_angle)) * HeadRadius * 0.6F
      Dim r As Single = BiteRadius + CSng(_rnd.NextDouble() * 0.2)
      _eatG.FillEllipse(Brushes.Black, mx - r, my - r, r * 2, r * 2)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' frmSS: onLoad
   Private Sub frmSS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Me.Bounds = _bounds

      For Each scr As Screen In Screen.AllScreens
         _screenRects.Add(New Rectangle(scr.Bounds.X - _bounds.X, scr.Bounds.Y - _bounds.Y, scr.Bounds.Width, scr.Bounds.Height))
      Next

      ' Random monitor, random point inside it, random heading
      Dim r As Rectangle = _screenRects(_rnd.Next(_screenRects.Count))
      Dim start As New PointF(r.X + _rnd.Next(100, Math.Max(101, r.Width - 100)),
                              r.Y + _rnd.Next(100, Math.Max(101, r.Height - 100)))
      _angle = _rnd.NextDouble() * 2 * Math.PI
      For i As Integer = 0 To SegmentCount - 1
         _segs(i) = start          ' all start stacked: the body "unwinds" as the head moves
      Next

      Cursor.Hide()
      _eatG = Graphics.FromImage(_screenshot)
      _eatG.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
      _timer.Start()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' frmSS: onFormClosed
   Private Sub frmSS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
      _timer.Stop()
      _eatG.Dispose()
      _screenshot.Dispose()
      Cursor.Show()
      Application.Exit()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' frmSS: onKeyDown
   Private Sub frmSS_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
      Me.Close()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' frmSS: onMouseDown
   Private Sub frmSS_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
      Me.Close()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' frmSS: onMouseMove
   Private Sub frmSS_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
      If _mouseStart.IsEmpty Then
         _mouseStart = e.Location
      ElseIf Math.Abs(e.X - _mouseStart.X) > 5 OrElse Math.Abs(e.Y - _mouseStart.Y) > 5 Then
         Me.Close()
      End If
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' _timer: OnTick: update the caterpillar's position, draw a bite, and invalidate the area that needs to be repainted
   Private Sub _timer_Tick(sender As Object, e As EventArgs) Handles _timer.Tick
      Dim before As Rectangle = BodyBounds()
      MoveCaterpillar()
      Eat()
      Invalidate(Rectangle.Union(before, BodyBounds()))
   End Sub

End Class
