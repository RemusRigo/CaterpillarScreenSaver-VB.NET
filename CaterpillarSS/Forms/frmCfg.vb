'--------------------------------------------------------------------------------------------------
' Caterpillar Screensaver: frmCfg.vb: Settings form'
'    © 2026 Remus Rigo
'       v1.0.20261011
'--------------------------------------------------------------------------------------------------

Imports CaterpillarSS.API
Public Class frmCfg

   Private _color As Color = AppSettings.BodyColor

   Private Const SYSMENU_ABOUT_ID As UInteger = 1000

   Protected Overrides Sub OnHandleCreated(e As EventArgs)
      MyBase.OnHandleCreated(e)
      Dim hSysMenu As IntPtr = GetSystemMenu(Me.Handle, False)
      ' Add a separator and then your custom item
      AppendMenu(hSysMenu, MF_SEPARATOR, 0, String.Empty)
      AppendMenu(hSysMenu, MF_STRING, SYSMENU_ABOUT_ID, "About...")
   End Sub

   Protected Overrides Sub WndProc(ByRef m As Message)
      MyBase.WndProc(m)
      If m.Msg = WM_SYSCOMMAND Then
         If CUInt(m.WParam) = SYSMENU_ABOUT_ID Then
            frmAbout.ShowDialog()
         End If
      End If
   End Sub

   '------------------------------------------------------------------------------------------------
   ' frmCfg: onLoad
   Private Sub frmCfg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      tbSpeed.Value = Math.Max(tbSpeed.Minimum, Math.Min(tbSpeed.Maximum, CInt(AppSettings.Speed * 10)))
      tbSize.Value = Math.Max(tbSize.Minimum, Math.Min(tbSize.Maximum, AppSettings.BodySize))
      btnColor.BackColor = _color

      lblSize.Text = "Size: " & tbSize.Value.ToString()
      lblSpeed.Text = "Speed: " & (tbSpeed.Value / 10.0F).ToString("0.0")
      pnlPreview.Invalidate()
   End Sub

   Private Sub tbSpeed_ValueChanged(sender As Object, e As EventArgs) Handles tbSpeed.ValueChanged
      'UpdateLabels()
      lblSpeed.Text = "Speed: " & (tbSpeed.Value / 10.0F).ToString("0.0")
      pnlPreview.Invalidate()
   End Sub

   Private Sub tbSize_ValueChanged(sender As Object, e As EventArgs) Handles tbSize.ValueChanged
      '      UpdateLabels()
      lblSize.Text = "Size: " & tbSize.Value.ToString()
      pnlPreview.Invalidate()
   End Sub

   Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
      Using dlg As New ColorDialog With {.Color = _color, .FullOpen = True}
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _color = dlg.Color
            btnColor.BackColor = _color
            pnlPreview.Invalidate()
         End If
      End Using
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' pnlPreview: onPaint
   Private Sub pnlPreview_Paint(sender As Object, e As PaintEventArgs) Handles pnlPreview.Paint
      Const Count As Integer = 16
      Dim size As Single = tbSize.Value
      Dim spacing As Single = size * 1.15F
      Dim total As Single = (Count - 1) * spacing + 2 * size
      Dim s As Single = Math.Min(1.0F, Math.Min((pnlPreview.Width - 20) / total, (pnlPreview.Height - 6) / (2 * size)))

      Dim g As Graphics = e.Graphics
      g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
      g.TranslateTransform(10, 0)
      g.ScaleTransform(s, s)

      Dim cy As Single = pnlPreview.Height / 2.0F / s
      Dim headX As Single = total - size

      For i As Integer = Count - 1 To 0 Step -1
         Dim rad As Single = size * (1.0F - 0.45F * i / (Count - 1))
         Dim x As Single = headX - i * spacing
         Dim fill As Color
         If i = 0 Then
            fill = AppSettings.Shade(_color, 0.6F)
         ElseIf i Mod 2 = 0 Then
            fill = _color
         Else
            fill = AppSettings.Shade(_color, 1.25F)
         End If
         Using br As New SolidBrush(fill), pen As New Pen(AppSettings.Shade(_color, 0.35F), 1.5F)
            g.FillEllipse(br, x - rad, cy - rad, rad * 2, rad * 2)
            g.DrawEllipse(pen, x - rad, cy - rad, rad * 2, rad * 2)
         End Using
      Next

      Dim er As Single = size * 0.28F
      Dim pr As Single = er * 0.5F
      ' head faces right, so the pupil shifts along +X:
      For Each side As Single In {-1.0F, 1.0F}
         Dim ex As Single = headX + size * 0.45F
         Dim ey As Single = cy + side * size * 0.45F
         'g.FillEllipse(Brushes.White, ex - 3, ey - 3, 6, 6)
         'g.FillEllipse(Brushes.Black, ex - 0.3F, ey - 1.5F, 3, 3)
         g.FillEllipse(Brushes.White, ex - er, ey - er, er * 2, er * 2)
         g.FillEllipse(Brushes.Black, ex + er * 0.4F - pr, ey - pr, pr * 2, pr * 2)
      Next
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' btnOK: onClick
   Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOk.Click
      AppSettings.Speed = tbSpeed.Value / 10.0F
      AppSettings.BodySize = tbSize.Value
      AppSettings.BodyColor = _color
      AppSettings.Save()
   End Sub

End Class