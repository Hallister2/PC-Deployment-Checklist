<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewPC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewPC))
        Me.txtbxRunningGPOResults = New System.Windows.Forms.TextBox()
        Me.lblContinueReplacement = New System.Windows.Forms.Label()
        Me.btnStartChecks = New System.Windows.Forms.Button()
        Me.btnSubmitContinueReplacement = New System.Windows.Forms.Button()
        Me.btnCancelContinueReplacement = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grpbxhrdwrChk = New System.Windows.Forms.GroupBox()
        Me.rdohrdwrchk_NA = New System.Windows.Forms.RadioButton()
        Me.rdohrdwrchk_NO = New System.Windows.Forms.RadioButton()
        Me.rdohrdwrchk_YES = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdogpo_NA = New System.Windows.Forms.RadioButton()
        Me.rdogpo_NO = New System.Windows.Forms.RadioButton()
        Me.rdogpo_YES = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdonetwork_NA = New System.Windows.Forms.RadioButton()
        Me.rdonetwork_NO = New System.Windows.Forms.RadioButton()
        Me.rdonetwork_YES = New System.Windows.Forms.RadioButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdoapps_NA = New System.Windows.Forms.RadioButton()
        Me.rdoapps_NO = New System.Windows.Forms.RadioButton()
        Me.rdoapps_YES = New System.Windows.Forms.RadioButton()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rdosccm_NA = New System.Windows.Forms.RadioButton()
        Me.rdosccm_NO = New System.Windows.Forms.RadioButton()
        Me.rdosccm_YES = New System.Windows.Forms.RadioButton()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.rdoepo_NA = New System.Windows.Forms.RadioButton()
        Me.rdoepo_NO = New System.Windows.Forms.RadioButton()
        Me.rdoepo_YES = New System.Windows.Forms.RadioButton()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.rdoautologin_NA = New System.Windows.Forms.RadioButton()
        Me.rdoautologin_NO = New System.Windows.Forms.RadioButton()
        Me.rdoautologin_YES = New System.Windows.Forms.RadioButton()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.tabresults = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtbxOverallStatus = New System.Windows.Forms.TextBox()
        Me.GPO = New System.Windows.Forms.TabPage()
        Me.Network = New System.Windows.Forms.TabPage()
        Me.txtbxRunningNetResults = New System.Windows.Forms.TextBox()
        Me.SCCM = New System.Windows.Forms.TabPage()
        Me.txtbxRunningSCCMResults = New System.Windows.Forms.TextBox()
        Me.txtOldPCNotes = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtNewPCNotes = New System.Windows.Forms.TextBox()
        Me.lblExisting = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtOldPrinters = New System.Windows.Forms.TextBox()
        Me.BackgroundWorkerGPOChk = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorkerNetChk = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorkerSCCM = New System.ComponentModel.BackgroundWorker()
        Me.pbrProgressGPO = New System.Windows.Forms.ProgressBar()
        Me.lblChecklistComplete = New System.Windows.Forms.Label()
        Me.grpbxhrdwrChk.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.tabresults.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GPO.SuspendLayout()
        Me.Network.SuspendLayout()
        Me.SCCM.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtbxRunningGPOResults
        '
        Me.txtbxRunningGPOResults.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtbxRunningGPOResults.ForeColor = System.Drawing.Color.LightGoldenrodYellow
        Me.txtbxRunningGPOResults.Location = New System.Drawing.Point(12, 9)
        Me.txtbxRunningGPOResults.Multiline = True
        Me.txtbxRunningGPOResults.Name = "txtbxRunningGPOResults"
        Me.txtbxRunningGPOResults.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtbxRunningGPOResults.Size = New System.Drawing.Size(465, 411)
        Me.txtbxRunningGPOResults.TabIndex = 291
        '
        'lblContinueReplacement
        '
        Me.lblContinueReplacement.AutoSize = True
        Me.lblContinueReplacement.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContinueReplacement.Location = New System.Drawing.Point(13, 8)
        Me.lblContinueReplacement.Name = "lblContinueReplacement"
        Me.lblContinueReplacement.Size = New System.Drawing.Size(352, 20)
        Me.lblContinueReplacement.TabIndex = 290
        Me.lblContinueReplacement.Text = "Continuing Replacement for: OLDPCNAME"
        '
        'btnStartChecks
        '
        Me.btnStartChecks.Location = New System.Drawing.Point(133, 60)
        Me.btnStartChecks.Name = "btnStartChecks"
        Me.btnStartChecks.Size = New System.Drawing.Size(224, 25)
        Me.btnStartChecks.TabIndex = 284
        Me.btnStartChecks.Text = "Click To Begin Checklist Verification"
        Me.btnStartChecks.UseVisualStyleBackColor = True
        '
        'btnSubmitContinueReplacement
        '
        Me.btnSubmitContinueReplacement.BackColor = System.Drawing.Color.ForestGreen
        Me.btnSubmitContinueReplacement.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmitContinueReplacement.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSubmitContinueReplacement.Location = New System.Drawing.Point(1204, 653)
        Me.btnSubmitContinueReplacement.Name = "btnSubmitContinueReplacement"
        Me.btnSubmitContinueReplacement.Size = New System.Drawing.Size(98, 35)
        Me.btnSubmitContinueReplacement.TabIndex = 282
        Me.btnSubmitContinueReplacement.Text = "Submit"
        Me.btnSubmitContinueReplacement.UseVisualStyleBackColor = False
        '
        'btnCancelContinueReplacement
        '
        Me.btnCancelContinueReplacement.BackColor = System.Drawing.Color.DarkRed
        Me.btnCancelContinueReplacement.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelContinueReplacement.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancelContinueReplacement.Location = New System.Drawing.Point(17, 653)
        Me.btnCancelContinueReplacement.Name = "btnCancelContinueReplacement"
        Me.btnCancelContinueReplacement.Size = New System.Drawing.Size(98, 35)
        Me.btnCancelContinueReplacement.TabIndex = 235
        Me.btnCancelContinueReplacement.Text = "Cancel"
        Me.btnCancelContinueReplacement.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 353)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(319, 20)
        Me.Label3.TabIndex = 239
        Me.Label3.Text = "After the autologin to Windows occurs:"
        '
        'grpbxhrdwrChk
        '
        Me.grpbxhrdwrChk.Controls.Add(Me.rdohrdwrchk_NA)
        Me.grpbxhrdwrChk.Controls.Add(Me.rdohrdwrchk_NO)
        Me.grpbxhrdwrChk.Controls.Add(Me.rdohrdwrchk_YES)
        Me.grpbxhrdwrChk.Controls.Add(Me.Label2)
        Me.grpbxhrdwrChk.Location = New System.Drawing.Point(17, 234)
        Me.grpbxhrdwrChk.Margin = New System.Windows.Forms.Padding(1)
        Me.grpbxhrdwrChk.Name = "grpbxhrdwrChk"
        Me.grpbxhrdwrChk.Padding = New System.Windows.Forms.Padding(1)
        Me.grpbxhrdwrChk.Size = New System.Drawing.Size(788, 48)
        Me.grpbxhrdwrChk.TabIndex = 293
        Me.grpbxhrdwrChk.TabStop = False
        '
        'rdohrdwrchk_NA
        '
        Me.rdohrdwrchk_NA.AutoSize = True
        Me.rdohrdwrchk_NA.Location = New System.Drawing.Point(72, 22)
        Me.rdohrdwrchk_NA.Name = "rdohrdwrchk_NA"
        Me.rdohrdwrchk_NA.Size = New System.Drawing.Size(14, 13)
        Me.rdohrdwrchk_NA.TabIndex = 240
        Me.rdohrdwrchk_NA.TabStop = True
        Me.rdohrdwrchk_NA.UseVisualStyleBackColor = True
        '
        'rdohrdwrchk_NO
        '
        Me.rdohrdwrchk_NO.AutoSize = True
        Me.rdohrdwrchk_NO.Location = New System.Drawing.Point(41, 22)
        Me.rdohrdwrchk_NO.Name = "rdohrdwrchk_NO"
        Me.rdohrdwrchk_NO.Size = New System.Drawing.Size(14, 13)
        Me.rdohrdwrchk_NO.TabIndex = 239
        Me.rdohrdwrchk_NO.TabStop = True
        Me.rdohrdwrchk_NO.UseVisualStyleBackColor = True
        '
        'rdohrdwrchk_YES
        '
        Me.rdohrdwrchk_YES.AutoSize = True
        Me.rdohrdwrchk_YES.Location = New System.Drawing.Point(11, 22)
        Me.rdohrdwrchk_YES.Name = "rdohrdwrchk_YES"
        Me.rdohrdwrchk_YES.Size = New System.Drawing.Size(14, 13)
        Me.rdohrdwrchk_YES.TabIndex = 238
        Me.rdohrdwrchk_YES.TabStop = True
        Me.rdohrdwrchk_YES.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(112, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(436, 20)
        Me.Label2.TabIndex = 237
        Me.Label2.Text = "Verify all physical hardware is fully configured on new system."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdogpo_NA)
        Me.GroupBox1.Controls.Add(Me.rdogpo_NO)
        Me.GroupBox1.Controls.Add(Me.rdogpo_YES)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 82)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(788, 48)
        Me.GroupBox1.TabIndex = 294
        Me.GroupBox1.TabStop = False
        '
        'rdogpo_NA
        '
        Me.rdogpo_NA.AutoSize = True
        Me.rdogpo_NA.Location = New System.Drawing.Point(72, 20)
        Me.rdogpo_NA.Name = "rdogpo_NA"
        Me.rdogpo_NA.Size = New System.Drawing.Size(14, 13)
        Me.rdogpo_NA.TabIndex = 287
        Me.rdogpo_NA.TabStop = True
        Me.rdogpo_NA.UseVisualStyleBackColor = True
        '
        'rdogpo_NO
        '
        Me.rdogpo_NO.AutoSize = True
        Me.rdogpo_NO.Location = New System.Drawing.Point(41, 20)
        Me.rdogpo_NO.Name = "rdogpo_NO"
        Me.rdogpo_NO.Size = New System.Drawing.Size(14, 13)
        Me.rdogpo_NO.TabIndex = 286
        Me.rdogpo_NO.TabStop = True
        Me.rdogpo_NO.UseVisualStyleBackColor = True
        '
        'rdogpo_YES
        '
        Me.rdogpo_YES.AutoSize = True
        Me.rdogpo_YES.Location = New System.Drawing.Point(11, 20)
        Me.rdogpo_YES.Name = "rdogpo_YES"
        Me.rdogpo_YES.Size = New System.Drawing.Size(14, 13)
        Me.rdogpo_YES.TabIndex = 285
        Me.rdogpo_YES.TabStop = True
        Me.rdogpo_YES.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(112, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(426, 20)
        Me.Label12.TabIndex = 237
        Me.Label12.Text = "Verify group policies are applying. (See GPO tab for results)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdonetwork_NA)
        Me.GroupBox2.Controls.Add(Me.rdonetwork_NO)
        Me.GroupBox2.Controls.Add(Me.rdonetwork_YES)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 132)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(788, 48)
        Me.GroupBox2.TabIndex = 295
        Me.GroupBox2.TabStop = False
        '
        'rdonetwork_NA
        '
        Me.rdonetwork_NA.AutoSize = True
        Me.rdonetwork_NA.Location = New System.Drawing.Point(72, 19)
        Me.rdonetwork_NA.Name = "rdonetwork_NA"
        Me.rdonetwork_NA.Size = New System.Drawing.Size(14, 13)
        Me.rdonetwork_NA.TabIndex = 240
        Me.rdonetwork_NA.TabStop = True
        Me.rdonetwork_NA.UseVisualStyleBackColor = True
        '
        'rdonetwork_NO
        '
        Me.rdonetwork_NO.AutoSize = True
        Me.rdonetwork_NO.Location = New System.Drawing.Point(41, 19)
        Me.rdonetwork_NO.Name = "rdonetwork_NO"
        Me.rdonetwork_NO.Size = New System.Drawing.Size(14, 13)
        Me.rdonetwork_NO.TabIndex = 239
        Me.rdonetwork_NO.TabStop = True
        Me.rdonetwork_NO.UseVisualStyleBackColor = True
        '
        'rdonetwork_YES
        '
        Me.rdonetwork_YES.AutoSize = True
        Me.rdonetwork_YES.Location = New System.Drawing.Point(11, 19)
        Me.rdonetwork_YES.Name = "rdonetwork_YES"
        Me.rdonetwork_YES.Size = New System.Drawing.Size(14, 13)
        Me.rdonetwork_YES.TabIndex = 238
        Me.rdonetwork_YES.TabStop = True
        Me.rdonetwork_YES.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(112, 14)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(575, 20)
        Me.Label16.TabIndex = 237
        Me.Label16.Text = "Verify Network Connectivity and no issues with ISE. (See Network tab for results)" &
    ""
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdoapps_NA)
        Me.GroupBox3.Controls.Add(Me.rdoapps_NO)
        Me.GroupBox3.Controls.Add(Me.rdoapps_YES)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 445)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(788, 48)
        Me.GroupBox3.TabIndex = 296
        Me.GroupBox3.TabStop = False
        '
        'rdoapps_NA
        '
        Me.rdoapps_NA.AutoSize = True
        Me.rdoapps_NA.Location = New System.Drawing.Point(73, 22)
        Me.rdoapps_NA.Name = "rdoapps_NA"
        Me.rdoapps_NA.Size = New System.Drawing.Size(14, 13)
        Me.rdoapps_NA.TabIndex = 243
        Me.rdoapps_NA.TabStop = True
        Me.rdoapps_NA.UseVisualStyleBackColor = True
        '
        'rdoapps_NO
        '
        Me.rdoapps_NO.AutoSize = True
        Me.rdoapps_NO.Location = New System.Drawing.Point(42, 22)
        Me.rdoapps_NO.Name = "rdoapps_NO"
        Me.rdoapps_NO.Size = New System.Drawing.Size(14, 13)
        Me.rdoapps_NO.TabIndex = 242
        Me.rdoapps_NO.TabStop = True
        Me.rdoapps_NO.UseVisualStyleBackColor = True
        '
        'rdoapps_YES
        '
        Me.rdoapps_YES.AutoSize = True
        Me.rdoapps_YES.Location = New System.Drawing.Point(12, 22)
        Me.rdoapps_YES.Name = "rdoapps_YES"
        Me.rdoapps_YES.Size = New System.Drawing.Size(14, 13)
        Me.rdoapps_YES.TabIndex = 241
        Me.rdoapps_YES.TabStop = True
        Me.rdoapps_YES.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(113, 17)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(302, 20)
        Me.Label17.TabIndex = 237
        Me.Label17.Text = "Verify Connect Care and Epic are present"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rdosccm_NA)
        Me.GroupBox4.Controls.Add(Me.rdosccm_NO)
        Me.GroupBox4.Controls.Add(Me.rdosccm_YES)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Location = New System.Drawing.Point(17, 182)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(788, 48)
        Me.GroupBox4.TabIndex = 297
        Me.GroupBox4.TabStop = False
        '
        'rdosccm_NA
        '
        Me.rdosccm_NA.AutoSize = True
        Me.rdosccm_NA.Location = New System.Drawing.Point(73, 22)
        Me.rdosccm_NA.Name = "rdosccm_NA"
        Me.rdosccm_NA.Size = New System.Drawing.Size(14, 13)
        Me.rdosccm_NA.TabIndex = 249
        Me.rdosccm_NA.TabStop = True
        Me.rdosccm_NA.UseVisualStyleBackColor = True
        '
        'rdosccm_NO
        '
        Me.rdosccm_NO.AutoSize = True
        Me.rdosccm_NO.Location = New System.Drawing.Point(42, 22)
        Me.rdosccm_NO.Name = "rdosccm_NO"
        Me.rdosccm_NO.Size = New System.Drawing.Size(14, 13)
        Me.rdosccm_NO.TabIndex = 248
        Me.rdosccm_NO.TabStop = True
        Me.rdosccm_NO.UseVisualStyleBackColor = True
        '
        'rdosccm_YES
        '
        Me.rdosccm_YES.AutoSize = True
        Me.rdosccm_YES.Location = New System.Drawing.Point(12, 22)
        Me.rdosccm_YES.Name = "rdosccm_YES"
        Me.rdosccm_YES.Size = New System.Drawing.Size(14, 13)
        Me.rdosccm_YES.TabIndex = 247
        Me.rdosccm_YES.TabStop = True
        Me.rdosccm_YES.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(113, 17)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(598, 20)
        Me.Label18.TabIndex = 237
        Me.Label18.Text = "Verfiy SCCM is installed and SMS Agent Host is started. (See SCCM tab for results" &
    ")"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.rdoepo_NA)
        Me.GroupBox7.Controls.Add(Me.rdoepo_NO)
        Me.GroupBox7.Controls.Add(Me.rdoepo_YES)
        Me.GroupBox7.Controls.Add(Me.Label21)
        Me.GroupBox7.Location = New System.Drawing.Point(17, 284)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupBox7.Size = New System.Drawing.Size(788, 48)
        Me.GroupBox7.TabIndex = 300
        Me.GroupBox7.TabStop = False
        '
        'rdoepo_NA
        '
        Me.rdoepo_NA.AutoSize = True
        Me.rdoepo_NA.Location = New System.Drawing.Point(73, 20)
        Me.rdoepo_NA.Name = "rdoepo_NA"
        Me.rdoepo_NA.Size = New System.Drawing.Size(14, 13)
        Me.rdoepo_NA.TabIndex = 249
        Me.rdoepo_NA.TabStop = True
        Me.rdoepo_NA.UseVisualStyleBackColor = True
        '
        'rdoepo_NO
        '
        Me.rdoepo_NO.AutoSize = True
        Me.rdoepo_NO.Location = New System.Drawing.Point(42, 20)
        Me.rdoepo_NO.Name = "rdoepo_NO"
        Me.rdoepo_NO.Size = New System.Drawing.Size(14, 13)
        Me.rdoepo_NO.TabIndex = 248
        Me.rdoepo_NO.TabStop = True
        Me.rdoepo_NO.UseVisualStyleBackColor = True
        '
        'rdoepo_YES
        '
        Me.rdoepo_YES.AutoSize = True
        Me.rdoepo_YES.Location = New System.Drawing.Point(12, 20)
        Me.rdoepo_YES.Name = "rdoepo_YES"
        Me.rdoepo_YES.Size = New System.Drawing.Size(14, 13)
        Me.rdoepo_YES.TabIndex = 247
        Me.rdoepo_YES.TabStop = True
        Me.rdoepo_YES.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(113, 15)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(329, 20)
        Me.Label21.TabIndex = 237
        Me.Label21.Text = "Verify McAfee EPO agent installed via SCCM."
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label26)
        Me.GroupBox8.Controls.Add(Me.rdoautologin_NA)
        Me.GroupBox8.Controls.Add(Me.rdoautologin_NO)
        Me.GroupBox8.Controls.Add(Me.rdoautologin_YES)
        Me.GroupBox8.Controls.Add(Me.Label22)
        Me.GroupBox8.Location = New System.Drawing.Point(17, 395)
        Me.GroupBox8.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupBox8.Size = New System.Drawing.Size(788, 48)
        Me.GroupBox8.TabIndex = 301
        Me.GroupBox8.TabStop = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(290, 20)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(456, 13)
        Me.Label26.TabIndex = 250
        Me.Label26.Text = "(If no; perform up to two reboots and confirm account is in AD and member of Auto" &
    " logon group)"
        '
        'rdoautologin_NA
        '
        Me.rdoautologin_NA.AutoSize = True
        Me.rdoautologin_NA.Location = New System.Drawing.Point(73, 20)
        Me.rdoautologin_NA.Name = "rdoautologin_NA"
        Me.rdoautologin_NA.Size = New System.Drawing.Size(14, 13)
        Me.rdoautologin_NA.TabIndex = 249
        Me.rdoautologin_NA.UseVisualStyleBackColor = True
        '
        'rdoautologin_NO
        '
        Me.rdoautologin_NO.AutoSize = True
        Me.rdoautologin_NO.Location = New System.Drawing.Point(42, 20)
        Me.rdoautologin_NO.Name = "rdoautologin_NO"
        Me.rdoautologin_NO.Size = New System.Drawing.Size(14, 13)
        Me.rdoautologin_NO.TabIndex = 248
        Me.rdoautologin_NO.UseVisualStyleBackColor = True
        '
        'rdoautologin_YES
        '
        Me.rdoautologin_YES.AutoSize = True
        Me.rdoautologin_YES.Location = New System.Drawing.Point(12, 20)
        Me.rdoautologin_YES.Name = "rdoautologin_YES"
        Me.rdoautologin_YES.Size = New System.Drawing.Size(14, 13)
        Me.rdoautologin_YES.TabIndex = 247
        Me.rdoautologin_YES.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(113, 15)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(171, 20)
        Me.Label22.TabIndex = 237
        Me.Label22.Text = "Verify Autologin occurs"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(21, 66)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(28, 13)
        Me.Label23.TabIndex = 302
        Me.Label23.Text = "YES"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(55, 66)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(23, 13)
        Me.Label24.TabIndex = 303
        Me.Label24.Text = "NO"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(84, 66)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(27, 13)
        Me.Label25.TabIndex = 304
        Me.Label25.Text = "N/A"
        '
        'tabresults
        '
        Me.tabresults.Controls.Add(Me.TabPage1)
        Me.tabresults.Controls.Add(Me.GPO)
        Me.tabresults.Controls.Add(Me.Network)
        Me.tabresults.Controls.Add(Me.SCCM)
        Me.tabresults.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabresults.Location = New System.Drawing.Point(811, 51)
        Me.tabresults.Name = "tabresults"
        Me.tabresults.SelectedIndex = 0
        Me.tabresults.Size = New System.Drawing.Size(491, 452)
        Me.tabresults.TabIndex = 306
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtbxOverallStatus)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(483, 423)
        Me.TabPage1.TabIndex = 4
        Me.TabPage1.Text = "Overall Status"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtbxOverallStatus
        '
        Me.txtbxOverallStatus.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtbxOverallStatus.ForeColor = System.Drawing.Color.LightGoldenrodYellow
        Me.txtbxOverallStatus.Location = New System.Drawing.Point(12, 9)
        Me.txtbxOverallStatus.Multiline = True
        Me.txtbxOverallStatus.Name = "txtbxOverallStatus"
        Me.txtbxOverallStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtbxOverallStatus.Size = New System.Drawing.Size(465, 411)
        Me.txtbxOverallStatus.TabIndex = 292
        '
        'GPO
        '
        Me.GPO.Controls.Add(Me.txtbxRunningGPOResults)
        Me.GPO.Location = New System.Drawing.Point(4, 25)
        Me.GPO.Name = "GPO"
        Me.GPO.Padding = New System.Windows.Forms.Padding(3)
        Me.GPO.Size = New System.Drawing.Size(483, 423)
        Me.GPO.TabIndex = 0
        Me.GPO.Text = "GPO"
        Me.GPO.UseVisualStyleBackColor = True
        '
        'Network
        '
        Me.Network.Controls.Add(Me.txtbxRunningNetResults)
        Me.Network.Location = New System.Drawing.Point(4, 25)
        Me.Network.Name = "Network"
        Me.Network.Size = New System.Drawing.Size(483, 423)
        Me.Network.TabIndex = 2
        Me.Network.Text = "Network"
        Me.Network.UseVisualStyleBackColor = True
        '
        'txtbxRunningNetResults
        '
        Me.txtbxRunningNetResults.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtbxRunningNetResults.ForeColor = System.Drawing.Color.LightGoldenrodYellow
        Me.txtbxRunningNetResults.Location = New System.Drawing.Point(12, 9)
        Me.txtbxRunningNetResults.Multiline = True
        Me.txtbxRunningNetResults.Name = "txtbxRunningNetResults"
        Me.txtbxRunningNetResults.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtbxRunningNetResults.Size = New System.Drawing.Size(465, 411)
        Me.txtbxRunningNetResults.TabIndex = 293
        '
        'SCCM
        '
        Me.SCCM.Controls.Add(Me.txtbxRunningSCCMResults)
        Me.SCCM.Location = New System.Drawing.Point(4, 25)
        Me.SCCM.Name = "SCCM"
        Me.SCCM.Padding = New System.Windows.Forms.Padding(3)
        Me.SCCM.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SCCM.Size = New System.Drawing.Size(483, 423)
        Me.SCCM.TabIndex = 1
        Me.SCCM.Text = "SCCM"
        Me.SCCM.UseVisualStyleBackColor = True
        '
        'txtbxRunningSCCMResults
        '
        Me.txtbxRunningSCCMResults.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtbxRunningSCCMResults.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbxRunningSCCMResults.ForeColor = System.Drawing.Color.LightGoldenrodYellow
        Me.txtbxRunningSCCMResults.Location = New System.Drawing.Point(12, 9)
        Me.txtbxRunningSCCMResults.Multiline = True
        Me.txtbxRunningSCCMResults.Name = "txtbxRunningSCCMResults"
        Me.txtbxRunningSCCMResults.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtbxRunningSCCMResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtbxRunningSCCMResults.Size = New System.Drawing.Size(465, 411)
        Me.txtbxRunningSCCMResults.TabIndex = 292
        '
        'txtOldPCNotes
        '
        Me.txtOldPCNotes.Location = New System.Drawing.Point(6, 4)
        Me.txtOldPCNotes.MaxLength = 5000
        Me.txtOldPCNotes.Multiline = True
        Me.txtOldPCNotes.Name = "txtOldPCNotes"
        Me.txtOldPCNotes.ReadOnly = True
        Me.txtOldPCNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOldPCNotes.Size = New System.Drawing.Size(1267, 108)
        Me.txtOldPCNotes.TabIndex = 307
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Location = New System.Drawing.Point(606, 653)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(98, 35)
        Me.btnSave.TabIndex = 309
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'txtNewPCNotes
        '
        Me.txtNewPCNotes.Location = New System.Drawing.Point(6, 6)
        Me.txtNewPCNotes.MaxLength = 5000
        Me.txtNewPCNotes.Multiline = True
        Me.txtNewPCNotes.Name = "txtNewPCNotes"
        Me.txtNewPCNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNewPCNotes.Size = New System.Drawing.Size(1267, 103)
        Me.txtNewPCNotes.TabIndex = 310
        '
        'lblExisting
        '
        Me.lblExisting.AutoSize = True
        Me.lblExisting.Location = New System.Drawing.Point(17, 32)
        Me.lblExisting.Name = "lblExisting"
        Me.lblExisting.Size = New System.Drawing.Size(97, 13)
        Me.lblExisting.TabIndex = 312
        Me.lblExisting.Text = "loading saved data"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(84, 384)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 315
        Me.Label5.Text = "N/A"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(55, 384)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 314
        Me.Label6.Text = "NO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 384)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 313
        Me.Label7.Text = "YES"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(17, 509)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1287, 138)
        Me.TabControl1.TabIndex = 316
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtOldPCNotes)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1279, 112)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.Text = "Notes From Old PC:"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txtNewPCNotes)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1279, 112)
        Me.TabPage3.TabIndex = 1
        Me.TabPage3.Text = "Notes For New PC:"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.txtOldPrinters)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1279, 112)
        Me.TabPage4.TabIndex = 2
        Me.TabPage4.Text = "Old PC Printers"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'txtOldPrinters
        '
        Me.txtOldPrinters.Location = New System.Drawing.Point(3, 3)
        Me.txtOldPrinters.MaxLength = 5000
        Me.txtOldPrinters.Multiline = True
        Me.txtOldPrinters.Name = "txtOldPrinters"
        Me.txtOldPrinters.ReadOnly = True
        Me.txtOldPrinters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOldPrinters.Size = New System.Drawing.Size(1267, 108)
        Me.txtOldPrinters.TabIndex = 317
        '
        'BackgroundWorkerGPOChk
        '
        Me.BackgroundWorkerGPOChk.WorkerReportsProgress = True
        '
        'BackgroundWorkerNetChk
        '
        '
        'BackgroundWorkerSCCM
        '
        '
        'pbrProgressGPO
        '
        Me.pbrProgressGPO.Location = New System.Drawing.Point(366, 61)
        Me.pbrProgressGPO.Name = "pbrProgressGPO"
        Me.pbrProgressGPO.Size = New System.Drawing.Size(439, 24)
        Me.pbrProgressGPO.Step = 20
        Me.pbrProgressGPO.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbrProgressGPO.TabIndex = 317
        Me.pbrProgressGPO.Visible = False
        '
        'lblChecklistComplete
        '
        Me.lblChecklistComplete.AutoSize = True
        Me.lblChecklistComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChecklistComplete.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblChecklistComplete.Location = New System.Drawing.Point(363, 64)
        Me.lblChecklistComplete.Name = "lblChecklistComplete"
        Me.lblChecklistComplete.Size = New System.Drawing.Size(258, 16)
        Me.lblChecklistComplete.TabIndex = 318
        Me.lblChecklistComplete.Text = "Auto Checklist Verification Complete"
        Me.lblChecklistComplete.Visible = False
        '
        'frmNewPC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1319, 698)
        Me.Controls.Add(Me.lblChecklistComplete)
        Me.Controls.Add(Me.pbrProgressGPO)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblExisting)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tabresults)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.btnStartChecks)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpbxhrdwrChk)
        Me.Controls.Add(Me.lblContinueReplacement)
        Me.Controls.Add(Me.btnSubmitContinueReplacement)
        Me.Controls.Add(Me.btnCancelContinueReplacement)
        Me.Controls.Add(Me.Label3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(1, 1)
        Me.Name = "frmNewPC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "BSMH Computer Replacement | Replacement"
        Me.grpbxhrdwrChk.ResumeLayout(False)
        Me.grpbxhrdwrChk.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.tabresults.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GPO.ResumeLayout(False)
        Me.GPO.PerformLayout()
        Me.Network.ResumeLayout(False)
        Me.Network.PerformLayout()
        Me.SCCM.ResumeLayout(False)
        Me.SCCM.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtbxRunningGPOResults As TextBox
    Friend WithEvents lblContinueReplacement As Label
    Friend WithEvents btnStartChecks As Button
    Friend WithEvents btnSubmitContinueReplacement As Button
    Friend WithEvents btnCancelContinueReplacement As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents grpbxhrdwrChk As GroupBox
    Friend WithEvents rdohrdwrchk_NA As RadioButton
    Friend WithEvents rdohrdwrchk_NO As RadioButton
    Friend WithEvents rdohrdwrchk_YES As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rdonetwork_NA As RadioButton
    Friend WithEvents rdonetwork_NO As RadioButton
    Friend WithEvents rdonetwork_YES As RadioButton
    Friend WithEvents Label16 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label17 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label18 As Label
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Label21 As Label
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents Label22 As Label
    Friend WithEvents rdoapps_NA As RadioButton
    Friend WithEvents rdoapps_NO As RadioButton
    Friend WithEvents rdoapps_YES As RadioButton
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents rdogpo_NA As RadioButton
    Friend WithEvents rdogpo_NO As RadioButton
    Friend WithEvents rdogpo_YES As RadioButton
    Friend WithEvents rdosccm_NA As RadioButton
    Friend WithEvents rdosccm_NO As RadioButton
    Friend WithEvents rdosccm_YES As RadioButton
    Friend WithEvents rdoepo_NA As RadioButton
    Friend WithEvents rdoepo_NO As RadioButton
    Friend WithEvents rdoepo_YES As RadioButton
    Friend WithEvents rdoautologin_NA As RadioButton
    Friend WithEvents rdoautologin_NO As RadioButton
    Friend WithEvents rdoautologin_YES As RadioButton
    Friend WithEvents Label26 As Label
    Friend WithEvents tabresults As TabControl
    Friend WithEvents GPO As TabPage
    Friend WithEvents SCCM As TabPage
    Friend WithEvents txtbxRunningSCCMResults As TextBox
    Friend WithEvents Network As TabPage
    Friend WithEvents txtbxRunningNetResults As TextBox
    Friend WithEvents txtOldPCNotes As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents txtNewPCNotes As TextBox
    Friend WithEvents lblExisting As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents txtbxOverallStatus As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents txtOldPrinters As TextBox
    Friend WithEvents BackgroundWorkerGPOChk As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorkerNetChk As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorkerSCCM As System.ComponentModel.BackgroundWorker
    Friend WithEvents pbrProgressGPO As ProgressBar
    Friend WithEvents lblChecklistComplete As Label
End Class
