<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.pnlLogin = New System.Windows.Forms.Panel()
        Me.lbllnkWebPage = New System.Windows.Forms.LinkLabel()
        Me.gbxLogin = New System.Windows.Forms.GroupBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.txtLoginID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlStartPage = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lbxComputerSelection = New System.Windows.Forms.ListBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.btnContinueReplacement = New System.Windows.Forms.Button()
        Me.btnNewPC = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblHello = New System.Windows.Forms.Label()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComputerReplacementAppDataSet = New PCDeploymentChecklist.ComputerReplacementAppDataSet()
        Me.OldPCBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OldPCTableAdapter = New PCDeploymentChecklist.ComputerReplacementAppDataSetTableAdapters.OldPCTableAdapter()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.pnlLogin.SuspendLayout()
        Me.gbxLogin.SuspendLayout()
        Me.pnlStartPage.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComputerReplacementAppDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OldPCBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlLogin
        '
        Me.pnlLogin.Controls.Add(Me.lblVersion)
        Me.pnlLogin.Controls.Add(Me.lbllnkWebPage)
        Me.pnlLogin.Controls.Add(Me.gbxLogin)
        Me.pnlLogin.Location = New System.Drawing.Point(12, 66)
        Me.pnlLogin.Name = "pnlLogin"
        Me.pnlLogin.Size = New System.Drawing.Size(463, 194)
        Me.pnlLogin.TabIndex = 2
        Me.pnlLogin.Visible = False
        '
        'lbllnkWebPage
        '
        Me.lbllnkWebPage.AutoSize = True
        Me.lbllnkWebPage.Location = New System.Drawing.Point(4, 178)
        Me.lbllnkWebPage.Name = "lbllnkWebPage"
        Me.lbllnkWebPage.Size = New System.Drawing.Size(117, 13)
        Me.lbllnkWebPage.TabIndex = 10
        Me.lbllnkWebPage.TabStop = True
        Me.lbllnkWebPage.Text = "PC Checklist Webpage"
        '
        'gbxLogin
        '
        Me.gbxLogin.Controls.Add(Me.btnLogin)
        Me.gbxLogin.Controls.Add(Me.txtLoginID)
        Me.gbxLogin.Controls.Add(Me.Label1)
        Me.gbxLogin.Location = New System.Drawing.Point(45, 34)
        Me.gbxLogin.Name = "gbxLogin"
        Me.gbxLogin.Size = New System.Drawing.Size(353, 105)
        Me.gbxLogin.TabIndex = 9
        Me.gbxLogin.TabStop = False
        Me.gbxLogin.Text = "Login"
        '
        'btnLogin
        '
        Me.btnLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.Location = New System.Drawing.Point(6, 67)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(341, 29)
        Me.btnLogin.TabIndex = 2
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'txtLoginID
        '
        Me.txtLoginID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoginID.Location = New System.Drawing.Point(132, 39)
        Me.txtLoginID.Name = "txtLoginID"
        Me.txtLoginID.Size = New System.Drawing.Size(85, 22)
        Me.txtLoginID.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(142, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User ID"
        '
        'pnlStartPage
        '
        Me.pnlStartPage.Controls.Add(Me.Label12)
        Me.pnlStartPage.Controls.Add(Me.btnRefresh)
        Me.pnlStartPage.Controls.Add(Me.lbxComputerSelection)
        Me.pnlStartPage.Controls.Add(Me.Splitter1)
        Me.pnlStartPage.Controls.Add(Me.btnContinueReplacement)
        Me.pnlStartPage.Controls.Add(Me.btnNewPC)
        Me.pnlStartPage.Controls.Add(Me.Label16)
        Me.pnlStartPage.Controls.Add(Me.lblHello)
        Me.pnlStartPage.Location = New System.Drawing.Point(481, 66)
        Me.pnlStartPage.Name = "pnlStartPage"
        Me.pnlStartPage.Size = New System.Drawing.Size(694, 501)
        Me.pnlStartPage.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(509, 166)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 13)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Current Work"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(486, 432)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(93, 26)
        Me.btnRefresh.TabIndex = 7
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'lbxComputerSelection
        '
        Me.lbxComputerSelection.DisplayMember = "InProgress"
        Me.lbxComputerSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbxComputerSelection.FormattingEnabled = True
        Me.lbxComputerSelection.ItemHeight = 20
        Me.lbxComputerSelection.Location = New System.Drawing.Point(286, 182)
        Me.lbxComputerSelection.Name = "lbxComputerSelection"
        Me.lbxComputerSelection.ScrollAlwaysVisible = True
        Me.lbxComputerSelection.Size = New System.Drawing.Size(293, 244)
        Me.lbxComputerSelection.TabIndex = 6
        Me.lbxComputerSelection.ValueMember = "InProgress"
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 501)
        Me.Splitter1.TabIndex = 5
        Me.Splitter1.TabStop = False
        '
        'btnContinueReplacement
        '
        Me.btnContinueReplacement.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContinueReplacement.Location = New System.Drawing.Point(286, 432)
        Me.btnContinueReplacement.Name = "btnContinueReplacement"
        Me.btnContinueReplacement.Size = New System.Drawing.Size(194, 27)
        Me.btnContinueReplacement.TabIndex = 1
        Me.btnContinueReplacement.Text = "Continue Replacement"
        Me.btnContinueReplacement.UseVisualStyleBackColor = True
        '
        'btnNewPC
        '
        Me.btnNewPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewPC.Location = New System.Drawing.Point(44, 167)
        Me.btnNewPC.Name = "btnNewPC"
        Me.btnNewPC.Size = New System.Drawing.Size(148, 27)
        Me.btnNewPC.TabIndex = 0
        Me.btnNewPC.Text = "Start a New PC Replacement"
        Me.btnNewPC.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(24, 50)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(587, 80)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = resources.GetString("Label16.Text")
        '
        'lblHello
        '
        Me.lblHello.AutoSize = True
        Me.lblHello.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHello.Location = New System.Drawing.Point(11, 14)
        Me.lblHello.Name = "lblHello"
        Me.lblHello.Size = New System.Drawing.Size(140, 20)
        Me.lblHello.TabIndex = 3
        Me.lblHello.Text = "Hello TechName"
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.Khaki
        Me.btnLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.Location = New System.Drawing.Point(477, 12)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(87, 48)
        Me.btnLogout.TabIndex = 2
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(459, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'ComputerReplacementAppDataSet
        '
        Me.ComputerReplacementAppDataSet.DataSetName = "ComputerReplacementAppDataSet"
        Me.ComputerReplacementAppDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'OldPCBindingSource
        '
        Me.OldPCBindingSource.DataMember = "OldPC"
        Me.OldPCBindingSource.DataSource = Me.ComputerReplacementAppDataSet
        '
        'OldPCTableAdapter
        '
        Me.OldPCTableAdapter.ClearBeforeFill = True
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(0, 0)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(42, 13)
        Me.lblVersion.TabIndex = 11
        Me.lblVersion.Text = "Version"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1193, 575)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.pnlLogin)
        Me.Controls.Add(Me.pnlStartPage)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(1, 1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "BSMH Computer Replacement"
        Me.pnlLogin.ResumeLayout(False)
        Me.pnlLogin.PerformLayout()
        Me.gbxLogin.ResumeLayout(False)
        Me.gbxLogin.PerformLayout()
        Me.pnlStartPage.ResumeLayout(False)
        Me.pnlStartPage.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComputerReplacementAppDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OldPCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlLogin As Panel
    Friend WithEvents gbxLogin As GroupBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents txtLoginID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlStartPage As Panel
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnContinueReplacement As Button
    Friend WithEvents btnNewPC As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblHello As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents lbxComputerSelection As ListBox
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents ComputerReplacementAppDataSet As ComputerReplacementAppDataSet
    Friend WithEvents OldPCBindingSource As BindingSource
    Friend WithEvents OldPCTableAdapter As ComputerReplacementAppDataSetTableAdapters.OldPCTableAdapter
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents lbllnkWebPage As LinkLabel
    Friend WithEvents lblVersion As Label
End Class
