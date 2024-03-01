'Ad these to the checklist
'Carepath Downtime Device
'UPS
'Type 2
'Wall Mount
'Credit Card Reader
'Admin Rights
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO
Imports System.Net.Mail

Public Class frmNewPC
    '################################ Start Declare Public Variables ################################
    Public Shared LoggedIn As String = 0
    Public Shared LoginID As String
    Public Shared UserFName As String
    Public Shared UserLName As String
    Public Shared ComputerName As String
    Public Shared ContinueMachineName As String
    Public Shared LoginCount As String
    Public Shared conn As String = "Server=MDCOAP104338\SQLEXPRESS;Database=ComputerReplacementApp;User Id=pcreplace;Password=Hb5#3XNbt5"
    Public Shared OldComputerName As String
    Public Shared OldPCID As String
    Public Shared NewPCName As String
    Public Shared today As DateTime = DateTime.Now
    Public Shared WorkerCompleted As Integer = 0

    '################################ End Declare Public Variables ################################

    Private Sub frmNewPC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.Hide()
        Me.Show()
        ComputerName = My.Computer.Name
        ContinueMachineName = Form1.lbxComputerSelection.SelectedItem.ToString()
        Dim OldPCInfo As String() = ContinueMachineName.Split(New Char() {" | "})
        OldPCID = OldPCInfo(0)
        OldComputerName = OldPCInfo(2)
        Me.lblContinueReplacement.Text = "Continuing Replacement for: " + OldComputerName + "  With System: " + ComputerName
        Dim Exists As String = "0"
        Dim PCProgress As Integer
        Dim NewPCConinue As String = ""
        Dim ExistingOldPC As String = ""
        Dim GPOchecks As Integer
        Dim Networkchecks As Integer
        Dim SCCMchecks As Integer
        Dim EPOchecks As Integer
        Dim HardWarechecks As Integer
        Dim AutoLoginchecks As Integer
        Dim Appchecks As Integer
        Dim NewPCNotes As String = ""
        Dim OldPCNotes As String = ""
        Dim OldPCPrinters As String = ""

        Try
            Using connection As New SqlConnection(conn)
                connection.Open()
                Dim NewPCCheckSQL As New SqlCommand("SELECT Count(*) AS [Count]
	                                                        ,n.ComputerName AS [NewPC]
	                                                        ,n.InProgress AS [InProgress]
	                                                        ,o.ComputerName AS [OldPC]
                                                        FROM NewPC n
	                                                        LEFT JOIN OldPC o ON n.OldPCID = o.id
                                                        WHERE n.OldPCID = '" & OldPCID & "' AND n.ComputerName = '" & ComputerName & "'
                                                        GROUP BY n.ComputerName
	                                                        ,n.InProgress
	                                                        ,o.ComputerName", connection)

                Dim NewPCCheckReader As SqlDataReader = NewPCCheckSQL.ExecuteReader()
                While NewPCCheckReader.Read()
                    Exists = NewPCCheckReader("Count")
                    PCProgress = NewPCCheckReader("InProgress")
                    ExistingOldPC = NewPCCheckReader("OldPC")
                End While
                connection.Close()
            End Using

            If Exists = "0" Then
                Me.lblExisting.Text = "Starting a new replacement checklist"
                Me.lblExisting.ForeColor = Color.Green

                Me.rdogpo_YES.Enabled = False
                Me.rdogpo_NO.Enabled = False
                Me.rdogpo_NA.Enabled = False
                Me.rdonetwork_YES.Enabled = False
                Me.rdonetwork_NO.Enabled = False
                Me.rdonetwork_NA.Enabled = False
                Me.rdosccm_YES.Enabled = False
                Me.rdosccm_NO.Enabled = False
                Me.rdosccm_NA.Enabled = False
                Me.rdoepo_YES.Enabled = False
                Me.rdoepo_NO.Enabled = False
                Me.rdoepo_NA.Enabled = False
                Me.rdohrdwrchk_YES.Enabled = False
                Me.rdohrdwrchk_NO.Enabled = False
                Me.rdohrdwrchk_NA.Enabled = False
                Me.rdoautologin_YES.Enabled = False
                Me.rdoautologin_NO.Enabled = False
                Me.rdoautologin_NA.Enabled = False
                Me.rdoapps_YES.Enabled = False
                Me.rdoapps_NO.Enabled = False
                Me.rdoapps_NA.Enabled = False

                Using connection As New SqlConnection(conn)
                    connection.Open()
                    Dim oldpcchecksql As New SqlCommand("SELECT Notes,Printers FROM OldPC WHERE id = '" & OldPCID & "'", connection)
                    Dim oldpccheckreader As SqlDataReader = oldpcchecksql.ExecuteReader()
                    While oldpccheckreader.Read()
                        OldPCNotes = oldpccheckreader("Notes")
                        OldPCPrinters = oldpccheckreader("Printers")
                    End While
                    connection.Close()
                End Using

            ElseIf Exists = "1" And PCProgress = 0 Then
                Me.lblExisting.Text = "A record with this system replacing old pc " + ExistingOldPC + " already exist. Loading fresh checklist if this is for new replacement"
                Me.lblExisting.ForeColor = Color.Red

                Me.rdogpo_YES.Enabled = False
                Me.rdogpo_NO.Enabled = False
                Me.rdogpo_NA.Enabled = False
                Me.rdonetwork_YES.Enabled = False
                Me.rdonetwork_NO.Enabled = False
                Me.rdonetwork_NA.Enabled = False
                Me.rdosccm_YES.Enabled = False
                Me.rdosccm_NO.Enabled = False
                Me.rdosccm_NA.Enabled = False
                Me.rdoepo_YES.Enabled = False
                Me.rdoepo_NO.Enabled = False
                Me.rdoepo_NA.Enabled = False
                Me.rdohrdwrchk_YES.Enabled = False
                Me.rdohrdwrchk_NO.Enabled = False
                Me.rdohrdwrchk_NA.Enabled = False
                Me.rdoautologin_YES.Enabled = False
                Me.rdoautologin_NO.Enabled = False
                Me.rdoautologin_NA.Enabled = False
                Me.rdoapps_YES.Enabled = False
                Me.rdoapps_NO.Enabled = False
                Me.rdoapps_NA.Enabled = False
                Using connection As New SqlConnection(conn)
                    connection.Open()
                    Dim NewPCCheckSQL As New SqlCommand("SELECT
	                                                        [dbo].[OldPC].[Printers] as 'Printers',
	                                                        [dbo].[OldPC].[Notes] AS 'OldNotes'
                                                        FROM OldPC
                                                        WHERE [dbo].[OldPC].[id] = '" & OldPCID & "'", connection)
                    Dim NewPCCheckReader As SqlDataReader = NewPCCheckSQL.ExecuteReader()
                    While NewPCCheckReader.Read()
                        OldPCNotes = NewPCCheckReader("OldNotes")
                        OldPCPrinters = NewPCCheckReader("Printers")
                    End While

                End Using
            Else
                Me.lblExisting.Text = "Replacement in progress. An existing checklist has been loaded."
                Me.lblExisting.ForeColor = Color.DarkGray

                Me.rdogpo_YES.Enabled = True
                Me.rdogpo_NO.Enabled = True
                Me.rdogpo_NA.Enabled = True
                Me.rdonetwork_YES.Enabled = True
                Me.rdonetwork_NO.Enabled = True
                Me.rdonetwork_NA.Enabled = True
                Me.rdosccm_YES.Enabled = True
                Me.rdosccm_NO.Enabled = True
                Me.rdosccm_NA.Enabled = True
                Me.rdoepo_YES.Enabled = True
                Me.rdoepo_NO.Enabled = True
                Me.rdoepo_NA.Enabled = True
                Me.rdohrdwrchk_YES.Enabled = True
                Me.rdohrdwrchk_NO.Enabled = True
                Me.rdohrdwrchk_NA.Enabled = True
                Me.rdoautologin_YES.Enabled = True
                Me.rdoautologin_NO.Enabled = True
                Me.rdoautologin_NA.Enabled = True
                Me.rdoapps_YES.Enabled = True
                Me.rdoapps_NO.Enabled = True
                Me.rdoapps_NA.Enabled = True

                'change radio buttons per saved checklist
                Using connection As New SqlConnection(conn)
                    connection.Open()
                    Dim NewPCCheckSQL As New SqlCommand("SELECT
	                                                        [dbo].[NewPC].[id] AS 'id',
	                                                        [dbo].[NewPC].[ComputerName] AS 'ComputerName',
	                                                        [dbo].[NewPC].[OldPCID] AS 'OldPCID',
	                                                        [dbo].[NewPC].[Check1] AS 'Check1',
	                                                        [dbo].[NewPC].[Check2] AS 'Check2',
	                                                        [dbo].[NewPC].[Check3] AS 'Check3',
	                                                        [dbo].[NewPC].[Check4] AS 'Check4',
	                                                        [dbo].[NewPC].[Check5] AS 'Check5',
	                                                        [dbo].[NewPC].[Check6] AS 'Check6',
	                                                        [dbo].[NewPC].[Check7] AS 'Check7',
	                                                        [dbo].[NewPC].[Notes] AS 'Notes',
	                                                        [dbo].[NewPC].[InProgress] AS 'InProgress',
	                                                        [dbo].[NewPC].[Date] AS 'Date',
	                                                        [dbo].[OldPC].[Printers] as 'Printers',
	                                                        [dbo].[OldPC].[Notes] AS 'OldNotes'
                                                        FROM NewPC 
                                                        Left Join OldPC
	                                                        on ([OldPC].id = NewPC.OldPCID)
                                                        WHERE [dbo].[NewPC].[OldPCID] = '" & OldPCID & "' AND [dbo].[NewPC].[ComputerName] = '" & ComputerName & "'", connection)
                    Dim NewPCCheckReader As SqlDataReader = NewPCCheckSQL.ExecuteReader()
                    While NewPCCheckReader.Read()
                        Dim index1 As Integer = NewPCCheckReader.GetOrdinal("Check1")
                        If Not NewPCCheckReader.IsDBNull(index1) Then
                            GPOchecks = NewPCCheckReader("Check1")
                        End If

                        Dim index2 As Integer = NewPCCheckReader.GetOrdinal("Check2")
                        If Not NewPCCheckReader.IsDBNull(index2) Then
                            Networkchecks = NewPCCheckReader("Check2")
                        End If

                        Dim index3 As Integer = NewPCCheckReader.GetOrdinal("Check3")
                        If Not NewPCCheckReader.IsDBNull(index3) Then
                            SCCMchecks = NewPCCheckReader("Check3")
                        End If

                        Dim index4 As Integer = NewPCCheckReader.GetOrdinal("Check4")
                        If Not NewPCCheckReader.IsDBNull(index4) Then
                            EPOchecks = NewPCCheckReader("Check4")
                        End If

                        Dim index5 As Integer = NewPCCheckReader.GetOrdinal("Check5")
                        If Not NewPCCheckReader.IsDBNull(index5) Then
                            HardWarechecks = NewPCCheckReader("Check5")
                        End If

                        Dim index6 As Integer = NewPCCheckReader.GetOrdinal("Check6")
                        If Not NewPCCheckReader.IsDBNull(index6) Then
                            AutoLoginchecks = NewPCCheckReader("Check6")
                        End If

                        Dim index7 As Integer = NewPCCheckReader.GetOrdinal("Check7")
                        If Not NewPCCheckReader.IsDBNull(index7) Then
                            Appchecks = NewPCCheckReader("Check7")
                        End If

                        NewPCNotes = NewPCCheckReader("Notes")
                        OldPCNotes = NewPCCheckReader("OldNotes")
                        OldPCPrinters = NewPCCheckReader("Printers")
                    End While
                    connection.Close()
                End Using
            End If

            Select Case GPOchecks
                Case 1
                    rdogpo_YES.Checked = True
                Case 2
                    rdogpo_NO.Checked = True
                Case 3
                    rdogpo_NA.Checked = True
                Case Else
                    'Do Nothing
            End Select

            Select Case Networkchecks
                Case 1
                    rdonetwork_YES.Checked = True
                Case 2
                    rdonetwork_NO.Checked = True
                Case 3
                    rdonetwork_NA.Checked = True
                Case Else
                    'Do Nothing
            End Select

            Select Case SCCMchecks
                Case 1
                    rdosccm_YES.Checked = True
                Case 2
                    rdosccm_NO.Checked = True
                Case 3
                    rdosccm_NA.Checked = True
                Case Else
                    'Do Nothing
            End Select

            Select Case EPOchecks
                Case 1
                    rdoepo_YES.Checked = True
                Case 2
                    rdoepo_NO.Checked = True
                Case 3
                    rdoepo_NA.Checked = True
                Case Else
                    'Do Nothing
            End Select

            Select Case HardWarechecks
                Case 1
                    rdohrdwrchk_YES.Checked = True
                Case 2
                    rdohrdwrchk_NO.Checked = True
                Case 3
                    rdohrdwrchk_NA.Checked = True
                Case Else
                    'Do Nothing
            End Select

            Select Case AutoLoginchecks
                Case 1
                    rdoautologin_YES.Checked = True
                Case 2
                    rdoautologin_NO.Checked = True
                Case 3
                    rdoautologin_NA.Checked = True
                Case Else
                    'Do Nothing
            End Select

            Select Case Appchecks
                Case 1
                    rdoapps_YES.Checked = True
                Case 2
                    rdoapps_NO.Checked = True
                Case 3
                    rdoapps_NA.Checked = True
                Case Else
                    'Do Nothing
            End Select

            Me.txtNewPCNotes.Text = NewPCNotes
            Me.txtOldPCNotes.Text = OldPCNotes
            Me.txtOldPrinters.Text = OldPCPrinters

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub btnStartChecks_Click(sender As Object, e As EventArgs) Handles btnStartChecks.Click
        Me.pbrProgressGPO.Visible = True
        Me.txtbxOverallStatus.Text = "Processing Automated Checks...Please Wait until complete! " + Environment.NewLine +
                                        "____________________________________________________" + Environment.NewLine +
                                        "____________________________________________________" + Environment.NewLine + Environment.NewLine + Environment.NewLine
        Me.txtbxOverallStatus.Refresh()

        'Check Run - GPO
        Me.txtbxOverallStatus.Text += "...GPO Check Running... " + Environment.NewLine + Environment.NewLine
        Me.txtbxOverallStatus.Refresh()
        BackgroundWorkerGPOChk.RunWorkerAsync()

        'Check Run - Network
        Me.txtbxOverallStatus.Text += "...Networked Check Running... " + Environment.NewLine + Environment.NewLine
        Me.txtbxOverallStatus.Refresh()
        BackgroundWorkerNetChk.RunWorkerAsync()


        'Check Run - SCCM
        Me.txtbxOverallStatus.Text += "...SCCM Check Running... " + Environment.NewLine + Environment.NewLine
        Me.txtbxOverallStatus.Refresh()
        BackgroundWorkerSCCM.RunWorkerAsync()

        'Enable rest of Radios
        Me.rdoepo_YES.Enabled = True
        Me.rdoepo_NO.Enabled = True
        Me.rdoepo_NA.Enabled = True
        Me.rdohrdwrchk_YES.Enabled = True
        Me.rdohrdwrchk_NO.Enabled = True
        Me.rdohrdwrchk_NA.Enabled = True
        Me.rdoautologin_YES.Enabled = True
        Me.rdoautologin_NO.Enabled = True
        Me.rdoautologin_NA.Enabled = True
        Me.rdoapps_YES.Enabled = True
        Me.rdoapps_NO.Enabled = True
        Me.rdoapps_NA.Enabled = True
        'Me.txtbxOverallStatus.Text += SystemChecks.Trigger_EPO()

    End Sub

    Private Sub btnCancelContinueReplacement_Click(sender As Object, e As EventArgs) Handles btnCancelContinueReplacement.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub AddNewPCData(ByVal inprog As Integer)
        Dim exists As Integer
        Dim GPOcheck As Integer
        Dim Netcheck As Integer
        Dim SCCMcheck As Integer
        Dim EPOcheck As Integer
        Dim HrdWrcheck As Integer
        Dim Autologincheck As Integer
        Dim Appscheck As Integer
        Dim NewNotes As String = Me.txtNewPCNotes.Text.ToString()
        Dim InProgress As Integer = inprog

        Try

            If rdogpo_YES.Checked = True Then
                GPOcheck = 1
            ElseIf rdogpo_NO.Checked = True Then
                GPOcheck = 2
            ElseIf rdogpo_NA.Checked = True Then
                GPOcheck = 3
            End If

            If rdonetwork_YES.Checked = True Then
                Netcheck = 1
            ElseIf rdonetwork_NO.Checked = True Then
                Netcheck = 2
            ElseIf rdonetwork_NA.Checked = True Then
                Netcheck = 3
            End If

            If rdosccm_YES.Checked = True Then
                SCCMcheck = 1
            ElseIf rdosccm_NO.Checked = True Then
                SCCMcheck = 2
            ElseIf rdosccm_NA.Checked = True Then
                SCCMcheck = 3
            End If

            If rdoepo_YES.Checked = True Then
                EPOcheck = 1
            ElseIf rdoepo_NO.Checked = True Then
                EPOcheck = 2
            ElseIf rdoepo_NA.Checked = True Then
                EPOcheck = 3
            End If

            If rdohrdwrchk_YES.Checked = True Then
                HrdWrcheck = 1
            ElseIf rdohrdwrchk_NO.Checked = True Then
                HrdWrcheck = 2
            ElseIf rdohrdwrchk_NA.Checked = True Then
                HrdWrcheck = 3
            End If

            If rdoautologin_YES.Checked = True Then
                Autologincheck = 1
            ElseIf rdoautologin_NO.Checked = True Then
                Autologincheck = 2
            ElseIf rdoautologin_NA.Checked = True Then
                Autologincheck = 3
            End If

            If rdoapps_YES.Checked = True Then
                Appscheck = 1
            ElseIf rdoapps_NO.Checked = True Then
                Appscheck = 2
            ElseIf rdoapps_NA.Checked = True Then
                Appscheck = 3
            End If

            'check for existing record
            Using connection As New SqlConnection(conn)
                connection.Open()
                Dim NEWpcchecksql As New SqlCommand("select count(*) as count from NewPC where ComputerName = '" & ComputerName & "'", connection)
                Dim NEWpccheckreader As SqlDataReader = NEWpcchecksql.ExecuteReader()
                While NEWpccheckreader.Read()
                    exists = NEWpccheckreader("count")
                End While
                connection.Close()
            End Using

            If exists = "0" Then
                'insert new record
                Using connection As New SqlConnection(conn)
                    Dim newpcinsertsql As New SqlCommand("insert into NewPC (ComputerName, OldPCID, Check1, Check2, Check3, Check4, Check5, Check6, Check7, Notes, InProgress, Date, csmtask) 
                                                        values ('" & ComputerName & "','" & OldPCID & "','" & GPOcheck & "','" & Netcheck & "','" & SCCMcheck & "','" & EPOcheck & "','" & HrdWrcheck & "','" & Autologincheck & "','" & Appscheck & "','" & NewNotes & "','" & InProgress & "','" & today & "','0')", connection)
                    connection.Open()
                    Dim newpcinsertreader As SqlDataReader = newpcinsertsql.ExecuteReader()
                    connection.Close()
                End Using
                'set OldPC as Complete IF Inprogress set to 0 (false)
                If (InProgress = 0) Then
                    Using connection As New SqlConnection(conn)
                        Dim OldPCCompletesql As New SqlCommand("UPDATE OldPC SET InProgress = '0' WHERE id = '" & OldPCID & "'", connection)
                        connection.Open()
                        Dim OldPCCompletereader As SqlDataReader = OldPCCompletesql.ExecuteReader()
                        connection.Close()
                    End Using

                    Send_Email()
                    MsgBox("Computer documentation has been uploaded and marked as complete. Email has been sent to CMS team", MsgBoxStyle.Information)
                Else
                    MsgBox("Computer documentation has been uploaded. You may continue at a later time.", MsgBoxStyle.Information)
                End If
                Me.Close()
                Form1.Show()
            Else
                'insert new record
                Using connection As New SqlConnection(conn)
                    Dim newpcupdatesql As New SqlCommand("UPDATE NewPC SET OldPCID = '" & OldPCID & "', Check1 = '" & GPOcheck & "', Check2 = '" & Netcheck & "', Check3 = '" & SCCMcheck & "', Check4 = '" & EPOcheck & "', Check5 = '" & HrdWrcheck & "', Check6 ='" & Autologincheck & "', Check7 = '" & Appscheck & "', Notes = '" & NewNotes & "', InProgress = '" & InProgress & "', Date = '" & today &
                                                        "' WHERE ComputerName = '" & ComputerName & "'", connection)
                    connection.Open()
                    Dim newpcupdatereader As SqlDataReader = newpcupdatesql.ExecuteReader()
                    connection.Close()
                End Using
                'set OldPC as Complete IF Inprogress set to 0 (false)
                If (InProgress = 0) Then
                    Using connection As New SqlConnection(conn)
                        Dim OldPCCompletesql As New SqlCommand("UPDATE OldPC SET InProgress = '0' WHERE id = '" & OldPCID & "'", connection)
                        connection.Open()
                        Dim OldPCCompletereader As SqlDataReader = OldPCCompletesql.ExecuteReader()
                        connection.Close()
                    End Using

                    MsgBox("Computer documentation has been uploaded and marked as complete." + Environment.NewLine + "Email will be sent to the CSM team automatically!", MsgBoxStyle.Information)
                Else
                    MsgBox("Computer documentation has been uploaded. You may continue at a later time.", MsgBoxStyle.Information)
                End If

                Me.Close()
                Form1.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        AddNewPCData(1)
    End Sub

    Private Sub btnSubmitContinueReplacement_Click(sender As Object, e As EventArgs) Handles btnSubmitContinueReplacement.Click
        Dim GPOcheckStatus As Boolean = False
        Dim NetcheckStatus As Boolean = False
        Dim SCCMcheckStatus As Boolean = False
        Dim EPOcheckStatus As Boolean = False
        Dim HrdWrcheckStatus As Boolean = False
        Dim AutologincheckStatus As Boolean = False
        Dim AppscheckStatus As Boolean = False
        Dim ComputerNameStatus As Boolean = False
        Dim OldPCIDStatus As Boolean = False

        If rdogpo_NA.Checked = True Or rdogpo_NO.Checked = True Or rdogpo_YES.Checked = True Then
            GPOcheckStatus = True
        Else
            MsgBox("Must Select GPO Check Status", MsgBoxStyle.Exclamation)
        End If

        If rdonetwork_NA.Checked = True Or rdonetwork_NO.Checked = True Or rdonetwork_YES.Checked = True Then
            NetcheckStatus = True
        Else
            MsgBox("Must Select Network Check Status", MsgBoxStyle.Exclamation)
        End If

        If rdosccm_NA.Checked = True Or rdosccm_NO.Checked = True Or rdosccm_YES.Checked = True Then
            SCCMcheckStatus = True
        Else
            MsgBox("Must Select SCCM Check Status", MsgBoxStyle.Exclamation)
        End If

        If rdoepo_NA.Checked = True Or rdoepo_NO.Checked = True Or rdoepo_YES.Checked = True Then
            EPOcheckStatus = True
        Else
            MsgBox("Must Select EPO Check Status", MsgBoxStyle.Exclamation)
        End If

        If rdohrdwrchk_NA.Checked = True Or rdohrdwrchk_NO.Checked = True Or rdohrdwrchk_YES.Checked = True Then
            HrdWrcheckStatus = True
        Else
            MsgBox("Must Select Hardware Check Status", MsgBoxStyle.Exclamation)
        End If

        If rdoautologin_NA.Checked = True Or rdoautologin_NO.Checked = True Or rdoautologin_YES.Checked = True Then
            AutologincheckStatus = True
        Else
            MsgBox("Must Select Autologin Check Status", MsgBoxStyle.Exclamation)
        End If

        If rdoapps_NA.Checked = True Or rdoapps_NO.Checked = True Or rdoapps_YES.Checked = True Then
            AppscheckStatus = True
        Else
            MsgBox("Must Select Connect Care and Epic Check Status", MsgBoxStyle.Exclamation)
        End If

        If ComputerName.Length > 0 Then
            ComputerNameStatus = True
        Else
            MsgBox("Unable to determine New PC ID", MsgBoxStyle.Exclamation)
        End If

        If OldPCID.Length > 0 Then
            OldPCIDStatus = True
        Else
            MsgBox("Unable to determine Old PC ID", MsgBoxStyle.Exclamation)
        End If

        If GPOcheckStatus = True And NetcheckStatus = True And SCCMcheckStatus = True And EPOcheckStatus = True And HrdWrcheckStatus = True And AutologincheckStatus = True And AppscheckStatus = True And ComputerNameStatus = True And OldPCIDStatus = True Then
            AddNewPCData(0)
        Else
            MsgBox("Fix Missing Values", MsgBoxStyle.Exclamation)
        End If

        'Send_Email()
    End Sub

    Private Sub Send_Email()
        Try
            Dim bsmhsmtp As New SmtpClient
            Dim e_mail As New MailMessage()
            Dim csmemail As String = ""
            Using connection As New SqlConnection(conn)
                connection.Open()
                Dim CurrentCSMsql As New SqlCommand("SELECT * FROM [dbo].[csmcontact]", connection)
                Dim CurrentCSMreader As SqlDataReader = CurrentCSMsql.ExecuteReader()
                While CurrentCSMreader.Read()
                    csmemail = CurrentCSMreader("csmemail")
                End While
                connection.Close()
            End Using

            bsmhsmtp.Host = "10.233.133.225"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("pcreplacement@mercy.com")
            e_mail.To.Add(csmemail)
            e_mail.Subject = "PC Replacement for Windows  Refresh (High Priority)"
            e_mail.IsBodyHtml = False
            e_mail.Body = "This is for the Windows migration and needs handled in a timely manor as patient care could be affected as printing is needed by Physicians and Employees. High Priority Issue." + Environment.NewLine + "Old PC: " + OldComputerName + Environment.NewLine + "New PC: " + ComputerName + Environment.NewLine + "Click this link to complete the CSM process within the checklist app (No further action will be required): http://mdcoap104338/pcchecklist/csmupdate.php?compid=" + ComputerName
            bsmhsmtp.Send(e_mail)
        Catch ex As Exception
            MsgBox("The email did not send. CSM has access to a webpage to view all changes. Please note this one for your records.", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmNewPC_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form1.Show()
    End Sub



    '########################################################################################
    '                                Background Workers
    '########################################################################################

    Private Sub BackgroundWorkerGPOChk_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerGPOChk.DoWork
        Try
            Dim output As String = ""

            'Dim script As String = "& gpresult /SCOPE computer /R"
            Dim script As String = "$ErrorActionPreference = 'SilentlyContinue';
                                    $gpresult = Invoke-Command -ScriptBlock {
                                                                    & cmd.exe /C gpresult /R;
                                                                } -ErrorAction SilentlyContinue;
                                    $returnstring = '';
                                    $appliedcomputervalues = '';
                                    $applieduservalues = '';
                                    $Error.Clear();
                                    try
                                    {
                                        if(!$gpresult)
                                        {
                                            $returnstring = 'Failed to run GPRESULT';
                                        }
                                        else
                                        {
                                            $gpcontentsplit = $gpresult.Split([System.Environment]::NewLine);
                                            $returnstring = '';
                                            $lineIndex = 0;
                                            [array]$result = @();
                                            [array]$computerresult = @();
                                            [array]$userresult = @();
                                            [array]$applieduservalues = @('USER');
                                            [array]$appliedcomputervalues = @('COMPUTER');

                                            $result += 'System: ' + $PCName;
                                            $result += 'Date_Created: ' + $CurrentDate;

                                            [array]$computerresult = @();
                                            [array]$userresult = @();
                                            $computerresult = $false;
                                            $userresult = $false;

                                            foreach($line in $gpcontentsplit)
                                            {
                                                $lineIndex += 1;

                                                switch($line)
                                                {
                                                    {$_ -like '*COMPUTER SETTINGS*' -or $computersection -eq $true}
                                                        {
                                                            $computersection = $true;
                                                            $userresult = $false;

                                                                if($gpcontentsplit[$lineIndex] -like '*Applied Group Policy Objects*' -or $appliedcomputerpolicies -eq $true)
                                                                {
                                                                    $appliedcomputerpolicies = $true;
                                                                    $appliedcomputervalues += $gpcontentsplit[$lineIndex-1];
                            
                                                                    if($gpcontentsplit[$lineIndex] -eq '')
                                                                    {
                                                                        $appliedcomputerpolicies = $false;  
                                                                        $appliedcomputerpolicies = $false;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    $computerresult += $gpcontentsplit[$lineIndex-1];
                                                                }
                                                        }
                                                    {$_ -like '*USER SETTINGS*' -or $userresult -eq $true}
                                                        {
                                                            $userresult = $true;
                                                            $computersection = $false;
                        
                                                                if($gpcontentsplit[$lineIndex] -like '*Applied Group Policy Objects*' -or $applieduserpolicies -eq $true)
                                                                {
                                                                    $applieduserpolicies = $true;
                                                                    $applieduservalues += $gpcontentsplit[$lineIndex-1];
                            
                                                                    if($gpcontentsplit[$lineIndex] -eq '')
                                                                    {
                                                                        $applieduserpolicies = $false;  
                                                                        $applieduserpolicies = $false;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    $userresult += $gpcontentsplit[$lineIndex-1];
                                                                }
                                                        }
                                                    Default
                                                        {
                                                            $returnstring = $gpresult + [System.Environment]::NewLine;
                                                        }
                                                }
                                            }
                                        }
                                    }
                                    catch 
                                    {
                                        $Error.GetEnumerator()
                                    }
                                    if($Error.Count -lt 1)
                                    {
                                        if($returnstring -eq 'Failed to run GPRESULT')
                                        {
                                            $returnstring;
                                        }
                                        else
                                        {
                                            $returnstring += $appliedcomputervalues + '|' + $applieduservalues;
                                            $returnstring;
                                        }
                                    }
                                    else
                                    { 
                                        $Error.GetEnumerator()
                                    }"

            Dim objProcess As New System.Diagnostics.Process()

            objProcess.StartInfo.FileName = "powershell.exe"
            objProcess.StartInfo.Arguments = script
            objProcess.StartInfo.RedirectStandardOutput = True
            objProcess.StartInfo.RedirectStandardError = True
            objProcess.StartInfo.UseShellExecute = False
            objProcess.StartInfo.CreateNoWindow = True
            objProcess.Start()

            Dim scriptoutput As String = objProcess.StandardOutput.ReadToEnd()
            Dim errors As String = objProcess.StandardError.ReadToEnd()

            output += "Output:" + Environment.NewLine
            output += scriptoutput + Environment.NewLine
            output += Environment.NewLine
            output += "Errors:" + Environment.NewLine
            output += errors + Environment.NewLine

            e.Result = output

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical)
        End Try
        WorkerCompleted += 1
        Me.pbrProgressGPO.Invoke(New MethodInvoker(AddressOf UpdateProgress))

    End Sub

    Private Sub BackgroundWorkerGPOChk_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerGPOChk.RunWorkerCompleted

        Me.txtbxRunningGPOResults.Text = "Processing GPO Check..." + Environment.NewLine
        Me.txtbxRunningGPOResults.Refresh()

        Dim GPOresultsplit As String()
        Dim GPOresultsplitcomputer As String = ""
        Dim GPOresultsplituser As String = ""
        Dim strGPOCheckResults As String = Me.txtbxRunningGPOResults.Text

        strGPOCheckResults += e.Result.ToString() 'SystemChecks.GPO_Check()

        Me.txtbxRunningGPOResults.Text = strGPOCheckResults

        If strGPOCheckResults Like "*|*" Then
            GPOresultsplit = strGPOCheckResults.Split("|")
            GPOresultsplitcomputer = GPOresultsplit(0).Replace("Processing GPO Check...", "")
            GPOresultsplituser = GPOresultsplit(1)
            GPOresultsplitcomputer = GPOresultsplitcomputer.Replace(Environment.NewLine & "Output:", "")
        End If

        If GPOresultsplitcomputer.Length > 5 And GPOresultsplitcomputer.Contains("Default Domain Policy") And GPOresultsplituser.Length > 5 And GPOresultsplituser.Contains("Default Domain Policy") Then
            rdogpo_YES.Checked = True
            Me.txtbxRunningGPOResults.ForeColor = System.Drawing.Color.ForestGreen
            Me.txtbxOverallStatus.Text += "GPO Check Successful" + Environment.NewLine + Environment.NewLine
        Else
            rdogpo_NO.Checked = True
            Me.txtbxRunningGPOResults.ForeColor = System.Drawing.Color.Red
            Me.txtbxOverallStatus.Text += "GPO Check Error" + Environment.NewLine + Environment.NewLine
        End If

        Me.txtbxOverallStatus.Refresh()

        Me.rdogpo_YES.Enabled = True
        Me.rdogpo_NO.Enabled = True
        Me.rdogpo_NA.Enabled = True
    End Sub

    Private Sub BackgroundWorkerNetChk_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerNetChk.DoWork
        Try
            Dim output As String = ""

            'Dim script As String = "& gpresult /SCOPE computer /R"
            Dim script As String = "$Error.Clear();
                                    [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12;

                                    try
                                    {
                                        $psvertbl = $PSVersionTable;
                                        [int]$psver = $psvertbl.PSVersion.Major;

                                        $URL = 'https://bsmhealth.service-now.com/hrportal';
                                        $result = '';
                                        $returnstatuscode = '';
                                        $returnstatusDescription = '';
                                        $netAdapter = '';
                                        $netName = '';
                                        $netStatus = '';
                                        $netSpeed = '';

                                        if($psver -ge 4)
                                        {
                                            try
                                            {
                                                $responseWR = Invoke-WebRequest $URL -TimeoutSec 30; 

                                                $returnstatuscode = $responseWR.StatusCode;
                                                $returnstatusDescription = $responseWR.StatusDescription;

                                                if($returnstatusDescription -eq 'OK' -or $returnstatuscode -eq '200') 
                                                {
                                                    $webreqresult = 'Site Check' + [System.Environment]::NewLine + 'URL: ' + $URL + ' is reachable.' + [System.Environment]::NewLine + 'Return Code: ' + $returnstatuscode + [System.Environment]::NewLine + 'Return Description: ' + $returnstatusDescription 
                                                }
                                                else 
                                                {
                                                    $webreqresult = 'Site Check' + [System.Environment]::NewLine + 'URL: ' + $URL + ' is unreachable.' + [System.Environment]::NewLine + 'Return Code: ' + $returnstatuscode + [System.Environment]::NewLine + 'Return Description: ' + $returnstatusDescription
                                                }
                                            }
                                            catch
                                            {
                                                $webreqresult = 'Site Check' + [System.Environment]::NewLine + 'URL: ' + $URL + ' is not accessable' + [System.Environment]::NewLine + 'Return Code: ' + $returnstatuscode + [System.Environment]::NewLine + 'Return Description: ' + $returnstatusDescription
                                            }

                                            try
                                            {
                                                $netAdapter = Get-NetAdapter | where{$_.Name -notlike '*Hyper-V*' -and $_.Name -notlike 'vEthernet*'} | Select Name,Status,Speed;
                                                $netName = $netAdapter.Name;
                                                $netStatus = $netAdapter.Status;
                                                $netSpeed = $netAdapter.Speed;

                                                $netadaptresult = 'NetAdapter Check' + [System.Environment]::NewLine + 'Name: ' + $netName + [System.Environment]::NewLine + 'Status: ' + $netStatus + [System.Environment]::NewLine + 'Speed: ' + $netSpeed;
                                            }
                                            catch
                                            {
                                                $netadaptresult = 'NetAdapter Check' + [System.Environment]::NewLine + 'Name: NA' + [System.Environment]::NewLine + 'Status: NA' + [System.Environment]::NewLine + 'Speed: NA';
                                            }
                                            try
                                            {
                                                $NetStats = Get-NetAdapter | Select-Object -Property Name, InterfaceDescription, MacAddress, FullDuplex, LinkSpeed;
                                                forEach ($d in $NetStats) {
                                                    $Duplex += [System.Environment]::NewLine + 'Card Name: ' + $d.Name + ' | Link Speed: ' + $d.LinkSpeed;
                                                }
                                            }
                                            catch
                                            {
                                                $Duplex = [System.Environment]::NewLine + 'Duplex: NA';
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                $request = [System.Net.WebRequest]::Create($URL);
                                                $request.Method = 'GET';
                                                [System.Net.WebResponse]$response = $request.getResponse();

                                                $returnstatuscode = $response.StatusCode;
                                                $returnstatusDescription = $response.StatusDescription;

                                                if($returnstatusDescription -eq 'OK' -or $returnstatuscode -eq '200' -or $returnstatuscode -eq 'OK') 
                                                {
                                                    $webreqresult = 'Site Check' + [System.Environment]::NewLine + 'URL: ' + $URL + ' is reachable.' + [System.Environment]::NewLine + 'Return Code: ' + $returnstatuscode + [System.Environment]::NewLine + 'Return Description: ' + $returnstatusDescription 
                                                }
                                                else 
                                                {
                                                    $webreqresult = 'Site Check' + [System.Environment]::NewLine + 'URL: ' + $URL + ' is unreachable.' + [System.Environment]::NewLine + 'Return Code: ' + $returnstatuscode + [System.Environment]::NewLine + 'Return Description: ' + $returnstatusDescription
                                                }
                                            }
                                            catch
                                            {
                                                $webreqresult = 'Site Check' + [System.Environment]::NewLine + 'URL: ' + $URL + ' is not accessable' + [System.Environment]::NewLine + 'Return Code: ' + $returnstatuscode + [System.Environment]::NewLine + 'Return Description: ' + $returnstatusDescription
                                            }
        
                                            try
                                            {
                                                $netAdapter = Get-WmiObject Win32_NetworkAdapter | where{$_.PhysicalAdapter -eq $true -and $_.NetConnectionID -notlike '*Hyper-V*' -and $_.NetConnectionID -notlike 'VEthernet*'} | select NetConnectionID,NetConnectionStatus,Speed;
                                                $netName = $netAdapter.NetConnectionID;
                                                $netStatus = if($netAdapter.NetConnectionStatus -eq '2'){'Up'}else{'Not Present'};
                                                $netSpeed = $netAdapter.Speed;

                                                $netadaptresult = 'NetAdapter Check' + [System.Environment]::NewLine + 'Name: ' + $netName + [System.Environment]::NewLine + 'Status: ' + $netStatus + [System.Environment]::NewLine + 'Speed: ' + $netSpeed;
                                            }
                                            catch
                                            {
                                                $netadaptresult = 'NetAdapter Check' + [System.Environment]::NewLine + 'Name: NA' + [System.Environment]::NewLine + 'Status: NA' + [System.Environment]::NewLine + 'Speed: NA';
                                            }
                                            try
                                            {
                                                $NetStats = Get-NetAdapter | Select-Object -Property Name, InterfaceDescription, MacAddress, FullDuplex, LinkSpeed;
                                                forEach ($d in $NetStats) {
                                                    $Duplex += [System.Environment]::NewLine + 'Card Name: ' + $d.Name + ' | Link Speed: ' + $d.LinkSpeed;
                                                }
                                            }
                                            catch
                                            {
                                                $Duplex = [System.Environment]::NewLine + 'Duplex: NA';
                                            }
                                        }
                                    } 
                                    catch 
                                    {
                                        throw $Error.GetEnumerator();
                                    }

                                    $result = $webreqresult + [System.Environment]::NewLine + [System.Environment]::NewLine + $netadaptresult + [System.Environment]::NewLine + $Duplex;

                                    $result;"

            Dim objProcess As New System.Diagnostics.Process()

            objProcess.StartInfo.FileName = "powershell.exe"
            objProcess.StartInfo.Arguments = script
            objProcess.StartInfo.RedirectStandardOutput = True
            objProcess.StartInfo.RedirectStandardError = True
            objProcess.StartInfo.UseShellExecute = False
            objProcess.StartInfo.CreateNoWindow = True
            objProcess.Start()

            Dim scriptoutput As String = objProcess.StandardOutput.ReadToEnd()
            Dim errors As String = objProcess.StandardError.ReadToEnd()

            output += "Output:" + Environment.NewLine
            output += scriptoutput + Environment.NewLine
            output += Environment.NewLine
            output += "Errors:" + Environment.NewLine
            output += errors + Environment.NewLine

            e.Result = output

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical)
        End Try
        WorkerCompleted += 1
        Me.pbrProgressGPO.Invoke(New MethodInvoker(AddressOf UpdateProgress))
    End Sub

    Private Sub BackgroundWorkerNetChk_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerNetChk.RunWorkerCompleted

        Me.txtbxRunningNetResults.Text = "Processing Network Check..." + Environment.NewLine
        Me.txtbxRunningNetResults.Refresh()
        Dim strNetCheckResults As String = Me.txtbxRunningNetResults.Text

        strNetCheckResults += e.Result.ToString() 'SystemChecks.Network_Check()
        Dim returnwebreqsplit As String()
        Dim returnwebreqvalue As String = ""
        Dim returnnetadaptsplit As String()
        Dim returnnetadaptvalue As String = ""

        Me.txtbxRunningNetResults.Text = strNetCheckResults

        Dim Netresultsplit As String() = strNetCheckResults.Split(Environment.NewLine)
        Dim Netresultsplitcomputer As String = Netresultsplit(0).Replace("Processing Network Check...", "")

        For Each net As String In Netresultsplit
            If net.Contains("Return Description") Then
                returnwebreqsplit = net.Split(":")
                returnwebreqvalue = returnwebreqsplit(1)
            End If

            If net.Contains("Status") Then
                returnnetadaptsplit = net.Split(":")
                returnnetadaptvalue = returnnetadaptsplit(1)
            End If
        Next

        returnwebreqvalue = returnwebreqvalue.Trim()
        returnnetadaptvalue = returnnetadaptvalue.Trim()

        If returnwebreqvalue = "OK" And returnnetadaptvalue = "Up" Then
            rdonetwork_YES.Checked = True
            Me.txtbxRunningNetResults.ForeColor = System.Drawing.Color.ForestGreen
            Me.txtbxOverallStatus.Text += "Network Check Successful... " + Environment.NewLine + Environment.NewLine
            'Me.txtbxOverallStatus.Text += "...Email Sent to CMS after Network Verification... " + Environment.NewLine
        Else
            rdonetwork_NO.Checked = True
            Me.txtbxRunningNetResults.ForeColor = System.Drawing.Color.Red
            Me.txtbxOverallStatus.Text += "Network Check Error... " + Environment.NewLine + Environment.NewLine
        End If

        Me.txtbxOverallStatus.Refresh()

        Me.rdonetwork_YES.Enabled = True
        Me.rdonetwork_NO.Enabled = True
        Me.rdonetwork_NA.Enabled = True
    End Sub

    Private Sub BackgroundWorkerSCCM_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerSCCM.DoWork
        Try
            Dim output As String = ""
            Dim script As String = "$Error.Clear();
                                    $PCName = $env:COMPUTERNAME;
                                    $CurrentDate = Get-Date -Format 'yyyy-MM-dd';


                                    try
                                    {
                                        $CCMLogRoot = 'C:\Windows\ccm\Logs';
                                        $CCMSetupRoot = 'C:\Windows\ccmsetup\Logs';

                                        $CCMClientWMIChk = $false;
                                        $CCMSetupLogChk = $false;
                                        $CCMLogCountChk = $false;
                                        $CCMServiceChk = $false;
                                        $CCMOverallChk = $false;

                                        $CCMLogDir = Get-ChildItem $CCMLogRoot -Force;
                                        $CCMLogDirCount = $CCMLogDir.Count;
                                        $CCMSetupLog = $CCMSetupRoot + '\ccmsetup.log';
                                        $ccmsetupexitcode = Get-Content $CCMSetupLog -Tail 1 -Force; 

                                        $ClientWMI = Get-WmiObject -Namespace root\ccm -Class SMS_Client -ErrorAction SilentlyContinue;

                                        if($ClientWMI -and $ClientWMI.ClientType -eq 1)
                                        {
                                            $CCMClientWMIChk = $true;
                                        }

                                        if($ccmsetupexitcode -like '*CcmSetup is exiting with return code 0*')
                                        {
                                            $CCMSetupLogChk = $true;
                                        }

                                        if($CCMLogDirCount -gt 70)
                                        {
                                            $CCMLogCountChk = $true;
                                        }

                                        $ccmexecservice = Get-Service CcmExec -ErrorAction SilentlyContinue;

                                        if($ccmexecservice -and $ccmexecservice.Status -eq 'Running')
                                        {
                                            $CCMServiceChk = $true;
                                        }

                                        if($CCMServiceChk -eq $true -and $CCMSetupLogChk -eq $true -and $CCMLogCountChk -eq $true)
                                        {
                                            $CCMOverallChk = $true;
                                        }
                                        $SCCMClientVersion = Get-WmiObject -NameSpace Root\CCM -Class Sms_Client | Select-Object ClientVersion

                                        $CCMResultObj = New-Object System.Object
                                        $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'System' -Value $PCName;
                                        $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'SCCM Version' -Value $ClientWMI.ClientVersion;
                                        $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'Date_Created' -Value $CurrentDate;
                                        $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'CCM_WMI_Client_Check' -Value $CCMClientWMIChk;
                                        $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'CCM_Service_Check' -Value $CCMServiceChk;
                                        $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'CCM_Setup_Check' -Value $CCMSetupLogChk;
                                        $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'CCM_Log_Dir_Check' -Value $CCMLogCountChk;
                                        $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'CCM_Overall_Check' -Value $CCMOverallChk;
                                    }
                                    catch
                                    {
                                        $Error.GetEnumerator(); 
                                    }

                                    if($Error.Count -gt 0)
                                    {
                                        throw $Error.GetEnumerator().ToString(); 
                                    }
                                    else
                                    {
                                        $CCMResultObj;
                                    }"
            Dim objProcess As New System.Diagnostics.Process()

            objProcess.StartInfo.FileName = "powershell.exe"
            objProcess.StartInfo.Arguments = script
            objProcess.StartInfo.RedirectStandardOutput = True
            objProcess.StartInfo.RedirectStandardError = True
            objProcess.StartInfo.UseShellExecute = False
            objProcess.StartInfo.CreateNoWindow = True
            objProcess.Start()

            Dim scriptoutput As String = objProcess.StandardOutput.ReadToEnd()
            Dim errors As String = objProcess.StandardError.ReadToEnd()

            output += "Output:" + Environment.NewLine
            output += scriptoutput + Environment.NewLine
            output += Environment.NewLine
            output += "Errors:" + Environment.NewLine
            output += errors + Environment.NewLine

            e.Result = output

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical)
        End Try
        WorkerCompleted += 1
        Me.pbrProgressGPO.Invoke(New MethodInvoker(AddressOf UpdateProgress))
    End Sub

    Private Sub BackgroundWorkerSCCM_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerSCCM.RunWorkerCompleted
        Me.txtbxRunningSCCMResults.Text = "Processing SCCM Check..." + Environment.NewLine

        Dim strSCCMCheckResults As String = Me.txtbxRunningSCCMResults.Text

        Dim strSCCMRunResults As String = e.Result.ToString() 'SystemChecks.SCCM_Check()
        strSCCMCheckResults += strSCCMRunResults.Trim()

        Me.txtbxRunningSCCMResults.Text = strSCCMCheckResults

        If strSCCMCheckResults.Length > 5 Then
            rdosccm_YES.Checked = True
            Me.txtbxRunningSCCMResults.ForeColor = System.Drawing.Color.ForestGreen
            Me.txtbxOverallStatus.Text += "SCCM Check Successful... " + Environment.NewLine + Environment.NewLine
        Else
            rdosccm_NO.Checked = True
            Me.txtbxRunningSCCMResults.ForeColor = System.Drawing.Color.Red
            Me.txtbxOverallStatus.Text += "SCCM Check Error... " + Environment.NewLine + Environment.NewLine
        End If

        Me.txtbxOverallStatus.Refresh()

        Me.rdosccm_YES.Enabled = True
        Me.rdosccm_NO.Enabled = True
        Me.rdosccm_NA.Enabled = True
    End Sub

    Private Sub UpdateProgress()
        If WorkerCompleted = 3 Then
            Me.pbrProgressGPO.Visible = False
            Me.lblChecklistComplete.Visible = True
        End If
    End Sub

End Class