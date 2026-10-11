<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
      lnkLblGitHub = New LinkLabel()
      lblTitle = New Label()
      lblVer = New Label()
      imgPayPal = New PictureBox()
      imgRevolut = New PictureBox()
      CType(imgPayPal, ComponentModel.ISupportInitialize).BeginInit()
      CType(imgRevolut, ComponentModel.ISupportInitialize).BeginInit()
      SuspendLayout()
      ' 
      ' lnkLblGitHub
      ' 
      lnkLblGitHub.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
      lnkLblGitHub.LinkBehavior = LinkBehavior.NeverUnderline
      lnkLblGitHub.Location = New Point(2, 82)
      lnkLblGitHub.Name = "lnkLblGitHub"
      lnkLblGitHub.Size = New Size(322, 36)
      lnkLblGitHub.TabIndex = 2
      lnkLblGitHub.TabStop = True
      lnkLblGitHub.Text = "appLink"
      lnkLblGitHub.TextAlign = ContentAlignment.MiddleCenter
      ' 
      ' lblTitle
      ' 
      lblTitle.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
      lblTitle.Font = New Font("Verdana", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
      lblTitle.Location = New Point(2, 0)
      lblTitle.Name = "lblTitle"
      lblTitle.Size = New Size(326, 56)
      lblTitle.TabIndex = 3
      lblTitle.Text = "appTitle"
      lblTitle.TextAlign = ContentAlignment.MiddleCenter
      ' 
      ' lblVer
      ' 
      lblVer.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
      lblVer.Font = New Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
      lblVer.Location = New Point(2, 56)
      lblVer.Name = "lblVer"
      lblVer.Size = New Size(326, 25)
      lblVer.TabIndex = 4
      lblVer.Text = "appVer"
      lblVer.TextAlign = ContentAlignment.MiddleCenter
      ' 
      ' imgPayPal
      ' 
      imgPayPal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
      imgPayPal.Image = CType(resources.GetObject("imgPayPal.Image"), Image)
      imgPayPal.Location = New Point(2, 130)
      imgPayPal.Name = "imgPayPal"
      imgPayPal.Size = New Size(64, 64)
      imgPayPal.TabIndex = 6
      imgPayPal.TabStop = False
      ' 
      ' imgRevolut
      ' 
      imgRevolut.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
      imgRevolut.Image = CType(resources.GetObject("imgRevolut.Image"), Image)
      imgRevolut.Location = New Point(258, 130)
      imgRevolut.Name = "imgRevolut"
      imgRevolut.Size = New Size(64, 64)
      imgRevolut.TabIndex = 7
      imgRevolut.TabStop = False
      ' 
      ' frmAbout
      ' 
      AutoScaleDimensions = New SizeF(7F, 15F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(329, 201)
      Controls.Add(imgRevolut)
      Controls.Add(imgPayPal)
      Controls.Add(lblVer)
      Controls.Add(lblTitle)
      Controls.Add(lnkLblGitHub)
      FormBorderStyle = FormBorderStyle.FixedSingle
      MaximizeBox = False
      MinimizeBox = False
      Name = "frmAbout"
      ShowIcon = False
      ShowInTaskbar = False
      StartPosition = FormStartPosition.CenterScreen
      Text = "About"
      CType(imgPayPal, ComponentModel.ISupportInitialize).EndInit()
      CType(imgRevolut, ComponentModel.ISupportInitialize).EndInit()
      ResumeLayout(False)
   End Sub

   Friend WithEvents lnkLblGitHub As LinkLabel
   Friend WithEvents lblTitle As Label
   Friend WithEvents lblVer As Label
   Friend WithEvents imgPayPal As PictureBox
   Friend WithEvents imgRevolut As PictureBox
End Class
