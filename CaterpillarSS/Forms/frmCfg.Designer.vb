<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCfg
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCfg))
      tbSpeed = New TrackBar()
      lblSpeed = New Label()
      tbSize = New TrackBar()
      lblSize = New Label()
      btnColor = New Button()
      pnlPreview = New Panel()
      btnOk = New Button()
      btnCancel = New Button()
      CType(tbSpeed, ComponentModel.ISupportInitialize).BeginInit()
      CType(tbSize, ComponentModel.ISupportInitialize).BeginInit()
      SuspendLayout()
      ' 
      ' tbSpeed
      ' 
      tbSpeed.Location = New Point(78, 2)
      tbSpeed.Maximum = 50
      tbSpeed.Minimum = 5
      tbSpeed.Name = "tbSpeed"
      tbSpeed.Size = New Size(297, 45)
      tbSpeed.TabIndex = 0
      tbSpeed.TickFrequency = 5
      tbSpeed.Value = 5
      ' 
      ' lblSpeed
      ' 
      lblSpeed.AutoSize = True
      lblSpeed.Location = New Point(12, 20)
      lblSpeed.Name = "lblSpeed"
      lblSpeed.Size = New Size(39, 15)
      lblSpeed.TabIndex = 1
      lblSpeed.Text = "Speed"
      ' 
      ' tbSize
      ' 
      tbSize.Location = New Point(78, 53)
      tbSize.Maximum = 24
      tbSize.Minimum = 8
      tbSize.Name = "tbSize"
      tbSize.Size = New Size(297, 45)
      tbSize.TabIndex = 2
      tbSize.TickFrequency = 2
      tbSize.Value = 8
      ' 
      ' lblSize
      ' 
      lblSize.AutoSize = True
      lblSize.Location = New Point(12, 53)
      lblSize.Name = "lblSize"
      lblSize.Size = New Size(27, 15)
      lblSize.TabIndex = 3
      lblSize.Text = "Size"
      ' 
      ' btnColor
      ' 
      btnColor.Location = New Point(12, 88)
      btnColor.Name = "btnColor"
      btnColor.Size = New Size(55, 23)
      btnColor.TabIndex = 4
      btnColor.Text = "Color"
      btnColor.UseVisualStyleBackColor = True
      ' 
      ' pnlPreview
      ' 
      pnlPreview.Location = New Point(393, 12)
      pnlPreview.Name = "pnlPreview"
      pnlPreview.Size = New Size(250, 250)
      pnlPreview.TabIndex = 5
      ' 
      ' btnOk
      ' 
      btnOk.DialogResult = DialogResult.OK
      btnOk.Location = New Point(12, 239)
      btnOk.Name = "btnOk"
      btnOk.Size = New Size(75, 23)
      btnOk.TabIndex = 6
      btnOk.Text = "Ok"
      btnOk.UseVisualStyleBackColor = True
      ' 
      ' btnCancel
      ' 
      btnCancel.DialogResult = DialogResult.Cancel
      btnCancel.Location = New Point(93, 239)
      btnCancel.Name = "btnCancel"
      btnCancel.Size = New Size(75, 23)
      btnCancel.TabIndex = 7
      btnCancel.Text = "Cancel"
      btnCancel.UseVisualStyleBackColor = True
      ' 
      ' frmCfg
      ' 
      AutoScaleDimensions = New SizeF(7F, 15F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(647, 269)
      Controls.Add(btnCancel)
      Controls.Add(btnOk)
      Controls.Add(pnlPreview)
      Controls.Add(btnColor)
      Controls.Add(lblSize)
      Controls.Add(tbSize)
      Controls.Add(lblSpeed)
      Controls.Add(tbSpeed)
      FormBorderStyle = FormBorderStyle.FixedDialog
      Icon = CType(resources.GetObject("$this.Icon"), Icon)
      MaximizeBox = False
      MinimizeBox = False
      Name = "frmCfg"
      StartPosition = FormStartPosition.CenterScreen
      Text = "Settings"
      CType(tbSpeed, ComponentModel.ISupportInitialize).EndInit()
      CType(tbSize, ComponentModel.ISupportInitialize).EndInit()
      ResumeLayout(False)
      PerformLayout()
   End Sub

   Friend WithEvents tbSpeed As TrackBar
   Friend WithEvents lblSpeed As Label
   Friend WithEvents tbSize As TrackBar
   Friend WithEvents lblSize As Label
   Friend WithEvents btnColor As Button
   Friend WithEvents pnlPreview As Panel
   Friend WithEvents btnOk As Button
   Friend WithEvents btnCancel As Button
End Class
