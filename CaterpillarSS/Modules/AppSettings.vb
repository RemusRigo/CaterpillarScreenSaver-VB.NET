'--------------------------------------------------------------------------------------------------
' Caterpillar Screensaver: AppSettings.vb: Application settings
'    © 2026 Remus Rigo
'       v1.0.20261012
'--------------------------------------------------------------------------------------------------

Imports Microsoft.Win32

Module AppSettings

   Private regAppPath As String = "Software\Remus RIGO\CaterpillarSS.VB-NET"

   Public Speed As Single = 1.5F    ' pixels per tick, 0.5 - 5.0
   Public BodySize As Integer = 8   ' head radius in pixels, 8 - 24
   Public BodyColor As Color = Color.FromArgb(120, 190, 60)

   Public Sub Load()
      Try
         Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(regAppPath)
            If key Is Nothing Then Return
            Speed = Math.Max(0.5F, Math.Min(5.0F, CInt(key.GetValue("Speed", CInt(Math.Round(Speed * 10)))) / 10.0F))
            BodySize = Math.Max(8, Math.Min(24, CInt(key.GetValue("Size", BodySize))))
            BodyColor = Color.FromArgb(255, Color.FromArgb(CInt(key.GetValue("Color", BodyColor.ToArgb()))))
         End Using
      Catch
         ' Unreadable registry: keep the defaults
      End Try
   End Sub

   Public Sub Save()
      Try
         Using key As RegistryKey = Registry.CurrentUser.CreateSubKey(regAppPath)
            key.SetValue("Speed", CInt(Math.Round(Speed * 10)), RegistryValueKind.DWord)
            key.SetValue("Size", BodySize, RegistryValueKind.DWord)
            key.SetValue("Color", BodyColor.ToArgb(), RegistryValueKind.DWord)
         End Using
      Catch
      End Try
   End Sub

   ' Lighter (>1) or darker (<1) version of a color
   Public Function Shade(c As Color, factor As Single) As Color
      Return Color.FromArgb(255, Math.Min(255, CInt(c.R * factor)), Math.Min(255, CInt(c.G * factor)), Math.Min(255, CInt(c.B * factor)))
   End Function

End Module
