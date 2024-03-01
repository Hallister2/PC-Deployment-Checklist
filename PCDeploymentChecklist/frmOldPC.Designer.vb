<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOldPC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOldPC))
        Me.btnCancelOldPC = New System.Windows.Forms.Button()
        Me.btnSubmitOldPC = New System.Windows.Forms.Button()
        Me.lblComputerADOU = New System.Windows.Forms.Label()
        Me.txtOldOU = New System.Windows.Forms.TextBox()
        Me.txtOldTechID = New System.Windows.Forms.TextBox()
        Me.lblTechnicianID = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOldCartSerial = New System.Windows.Forms.TextBox()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.lblPrinters = New System.Windows.Forms.Label()
        Me.txtOldHostname = New System.Windows.Forms.TextBox()
        Me.lblCartSerial = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblOldHost = New System.Windows.Forms.Label()
        Me.txtOldNotes = New System.Windows.Forms.TextBox()
        Me.txtOldPrinters = New System.Windows.Forms.TextBox()
        Me.pnlExisting = New System.Windows.Forms.Panel()
        Me.btnExistingFresh = New System.Windows.Forms.Button()
        Me.btnExistsModify = New System.Windows.Forms.Button()
        Me.btnExistsCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BackgroundWorkerADGrps = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorkerPrinters = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorkerGetOU = New System.ComponentModel.BackgroundWorker()
        Me.pnlExisting.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelOldPC
        '
        Me.btnCancelOldPC.BackColor = System.Drawing.Color.DarkRed
        Me.btnCancelOldPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelOldPC.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancelOldPC.Location = New System.Drawing.Point(16, 445)
        Me.btnCancelOldPC.Name = "btnCancelOldPC"
        Me.btnCancelOldPC.Size = New System.Drawing.Size(98, 35)
        Me.btnCancelOldPC.TabIndex = 64
        Me.btnCancelOldPC.Text = "Cancel"
        Me.btnCancelOldPC.UseVisualStyleBackColor = False
        '
        'btnSubmitOldPC
        '
        Me.btnSubmitOldPC.BackColor = System.Drawing.Color.ForestGreen
        Me.btnSubmitOldPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmitOldPC.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSubmitOldPC.Location = New System.Drawing.Point(572, 445)
        Me.btnSubmitOldPC.Name = "btnSubmitOldPC"
        Me.btnSubmitOldPC.Size = New System.Drawing.Size(98, 35)
        Me.btnSubmitOldPC.TabIndex = 63
        Me.btnSubmitOldPC.Text = "Submit"
        Me.btnSubmitOldPC.UseVisualStyleBackColor = False
        '
        'lblComputerADOU
        '
        Me.lblComputerADOU.AutoSize = True
        Me.lblComputerADOU.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComputerADOU.Location = New System.Drawing.Point(12, 121)
        Me.lblComputerADOU.Name = "lblComputerADOU"
        Me.lblComputerADOU.Size = New System.Drawing.Size(134, 20)
        Me.lblComputerADOU.TabIndex = 62
        Me.lblComputerADOU.Text = "Computer AD OU"
        '
        'txtOldOU
        '
        Me.txtOldOU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldOU.Location = New System.Drawing.Point(174, 121)
        Me.txtOldOU.MaxLength = 300
        Me.txtOldOU.Name = "txtOldOU"
        Me.txtOldOU.Size = New System.Drawing.Size(496, 20)
        Me.txtOldOU.TabIndex = 61
        '
        'txtOldTechID
        '
        Me.txtOldTechID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldTechID.Location = New System.Drawing.Point(174, 9)
        Me.txtOldTechID.Name = "txtOldTechID"
        Me.txtOldTechID.ReadOnly = True
        Me.txtOldTechID.Size = New System.Drawing.Size(250, 22)
        Me.txtOldTechID.TabIndex = 60
        '
        'lblTechnicianID
        '
        Me.lblTechnicianID.AutoSize = True
        Me.lblTechnicianID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTechnicianID.Location = New System.Drawing.Point(12, 9)
        Me.lblTechnicianID.Name = "lblTechnicianID"
        Me.lblTechnicianID.Size = New System.Drawing.Size(106, 20)
        Me.lblTechnicianID.TabIndex = 59
        Me.lblTechnicianID.Text = "Technician ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 294)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 20)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Additional Notes"
        '
        'txtOldCartSerial
        '
        Me.txtOldCartSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldCartSerial.Location = New System.Drawing.Point(174, 93)
        Me.txtOldCartSerial.MaxLength = 100
        Me.txtOldCartSerial.Name = "txtOldCartSerial"
        Me.txtOldCartSerial.Size = New System.Drawing.Size(250, 22)
        Me.txtOldCartSerial.TabIndex = 56
        '
        'txtLocation
        '
        Me.txtLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocation.Location = New System.Drawing.Point(174, 65)
        Me.txtLocation.MaxLength = 200
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(250, 22)
        Me.txtLocation.TabIndex = 55
        '
        'lblPrinters
        '
        Me.lblPrinters.AutoSize = True
        Me.lblPrinters.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrinters.Location = New System.Drawing.Point(12, 149)
        Me.lblPrinters.Name = "lblPrinters"
        Me.lblPrinters.Size = New System.Drawing.Size(63, 20)
        Me.lblPrinters.TabIndex = 54
        Me.lblPrinters.Text = "Printers"
        '
        'txtOldHostname
        '
        Me.txtOldHostname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldHostname.Location = New System.Drawing.Point(174, 37)
        Me.txtOldHostname.Name = "txtOldHostname"
        Me.txtOldHostname.ReadOnly = True
        Me.txtOldHostname.Size = New System.Drawing.Size(250, 22)
        Me.txtOldHostname.TabIndex = 53
        '
        'lblCartSerial
        '
        Me.lblCartSerial.AutoSize = True
        Me.lblCartSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartSerial.Location = New System.Drawing.Point(12, 95)
        Me.lblCartSerial.Name = "lblCartSerial"
        Me.lblCartSerial.Size = New System.Drawing.Size(96, 20)
        Me.lblCartSerial.TabIndex = 52
        Me.lblCartSerial.Text = "Cart Serial #"
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.Location = New System.Drawing.Point(12, 67)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(70, 20)
        Me.lblLocation.TabIndex = 51
        Me.lblLocation.Text = "Location"
        '
        'lblOldHost
        '
        Me.lblOldHost.AutoSize = True
        Me.lblOldHost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOldHost.Location = New System.Drawing.Point(12, 39)
        Me.lblOldHost.Name = "lblOldHost"
        Me.lblOldHost.Size = New System.Drawing.Size(111, 20)
        Me.lblOldHost.TabIndex = 50
        Me.lblOldHost.Text = "Old Hostname"
        '
        'txtOldNotes
        '
        Me.txtOldNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldNotes.Location = New System.Drawing.Point(174, 294)
        Me.txtOldNotes.MaxLength = 5000
        Me.txtOldNotes.Multiline = True
        Me.txtOldNotes.Name = "txtOldNotes"
        Me.txtOldNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOldNotes.Size = New System.Drawing.Size(496, 132)
        Me.txtOldNotes.TabIndex = 58
        '
        'txtOldPrinters
        '
        Me.txtOldPrinters.AllowDrop = True
        Me.txtOldPrinters.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldPrinters.Location = New System.Drawing.Point(174, 149)
        Me.txtOldPrinters.MaxLength = 5000
        Me.txtOldPrinters.Multiline = True
        Me.txtOldPrinters.Name = "txtOldPrinters"
        Me.txtOldPrinters.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOldPrinters.Size = New System.Drawing.Size(496, 129)
        Me.txtOldPrinters.TabIndex = 66
        Me.txtOldPrinters.WordWrap = False
        '
        'pnlExisting
        '
        Me.pnlExisting.Controls.Add(Me.btnExistingFresh)
        Me.pnlExisting.Controls.Add(Me.btnExistsModify)
        Me.pnlExisting.Controls.Add(Me.btnExistsCancel)
        Me.pnlExisting.Controls.Add(Me.Label1)
        Me.pnlExisting.Location = New System.Drawing.Point(695, 12)
        Me.pnlExisting.Name = "pnlExisting"
        Me.pnlExisting.Size = New System.Drawing.Size(542, 122)
        Me.pnlExisting.TabIndex = 67
        '
        'btnExistingFresh
        '
        Me.btnExistingFresh.BackColor = System.Drawing.Color.Olive
        Me.btnExistingFresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExistingFresh.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExistingFresh.Location = New System.Drawing.Point(193, 77)
        Me.btnExistingFresh.Name = "btnExistingFresh"
        Me.btnExistingFresh.Size = New System.Drawing.Size(142, 35)
        Me.btnExistingFresh.TabIndex = 69
        Me.btnExistingFresh.Text = "Start Fresh"
        Me.btnExistingFresh.UseVisualStyleBackColor = False
        '
        'btnExistsModify
        '
        Me.btnExistsModify.BackColor = System.Drawing.Color.ForestGreen
        Me.btnExistsModify.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExistsModify.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExistsModify.Location = New System.Drawing.Point(384, 79)
        Me.btnExistsModify.Name = "btnExistsModify"
        Me.btnExistsModify.Size = New System.Drawing.Size(142, 35)
        Me.btnExistsModify.TabIndex = 68
        Me.btnExistsModify.Text = "Modify Existing"
        Me.btnExistsModify.UseVisualStyleBackColor = False
        '
        'btnExistsCancel
        '
        Me.btnExistsCancel.BackColor = System.Drawing.Color.DarkRed
        Me.btnExistsCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExistsCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExistsCancel.Location = New System.Drawing.Point(22, 77)
        Me.btnExistsCancel.Name = "btnExistsCancel"
        Me.btnExistsCancel.Size = New System.Drawing.Size(98, 35)
        Me.btnExistsCancel.TabIndex = 68
        Me.btnExistsCancel.Text = "Cancel"
        Me.btnExistsCancel.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(423, 40)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "A Computer with this name has already started processing." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please choose and opti" &
    "on below:"
        '
        'BackgroundWorkerADGrps
        '
        '
        'BackgroundWorkerPrinters
        '
        '
        'BackgroundWorkerGetOU
        '
        '
        'frmOldPC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 492)
        Me.Controls.Add(Me.pnlExisting)
        Me.Controls.Add(Me.txtOldPrinters)
        Me.Controls.Add(Me.btnCancelOldPC)
        Me.Controls.Add(Me.btnSubmitOldPC)
        Me.Controls.Add(Me.lblComputerADOU)
        Me.Controls.Add(Me.txtOldOU)
        Me.Controls.Add(Me.txtOldTechID)
        Me.Controls.Add(Me.lblTechnicianID)
        Me.Controls.Add(Me.txtOldNotes)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtOldCartSerial)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.lblPrinters)
        Me.Controls.Add(Me.txtOldHostname)
        Me.Controls.Add(Me.lblCartSerial)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.lblOldHost)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(1, 1)
        Me.Name = "frmOldPC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "BSMH Computer Replacement | Old PC"
        Me.pnlExisting.ResumeLayout(False)
        Me.pnlExisting.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancelOldPC As Button
    Friend WithEvents btnSubmitOldPC As Button
    Friend WithEvents lblComputerADOU As Label
    Friend WithEvents txtOldOU As TextBox
    Friend WithEvents txtOldTechID As TextBox
    Friend WithEvents lblTechnicianID As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtOldCartSerial As TextBox
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents lblPrinters As Label
    Friend WithEvents txtOldHostname As TextBox
    Friend WithEvents lblCartSerial As Label
    Friend WithEvents lblLocation As Label
    Friend WithEvents lblOldHost As Label
    Friend WithEvents txtOldNotes As TextBox
    Friend WithEvents txtOldPrinters As TextBox
    Friend WithEvents pnlExisting As Panel
    Friend WithEvents btnExistingFresh As Button
    Friend WithEvents btnExistsModify As Button
    Friend WithEvents btnExistsCancel As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents BackgroundWorkerADGrps As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorkerPrinters As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorkerGetOU As System.ComponentModel.BackgroundWorker
End Class
