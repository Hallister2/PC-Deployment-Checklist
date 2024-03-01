Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO

Public Class frmOldPC
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
    Public Shared OldPCInProgress As String
    Public Shared OldHostname As String
    Public Shared OldLocation As String
    Public Shared OldCartSerial As String
    Public Shared OldComputerADOU As String
    Public Shared OldPrinters As String
    Public Shared OldAdditionalNotes As String
    Public Shared Exists As String
    Public Shared today As DateTime = DateTime.Now
    Public Shared adgroups As String
    '################################ End Declare Public Variables ################################
    '################################ Start Get PC Name  ################################
    Private Sub GetComputerName()
        ComputerName = System.Net.Dns.GetHostName
    End Sub
    '################################ End Get PC Name ################################
    '################################ Start Get Printer List ################################
    Private Sub btnGetPrinters_Click_1(sender As Object, e As EventArgs)
        'Dim pkInstalledPrinters As String
        'System.Threading.ThreadPool.QueueUserWorkItem(AddressOf SystemChecks.Get_ADMembership)
        'pkInstalledPrinters = SystemChecks.Gather_Printers()
        'Me.txtOldNotes.Text = adgroups
        'Me.txtOldPrinters.Text = pkInstalledPrinters
    End Sub
    '################################ End Get Printer List ################################
    '################################ Start Process Old PC ################################
    Private Sub frmOldPC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 694
        Me.Height = 527

        Form1.Hide()
        Me.Show()

        Call GetComputerName()
        Me.txtOldHostname.Text = ComputerName
        Me.txtOldTechID.Text = Form1.LoginID
        LoginID = Form1.LoginID

        'Check for existing record
        Using connection As New SqlConnection(conn)
            connection.Open()
            Dim OldPCCheckSQL As New SqlCommand("SELECT Count(*) As Count FROM OldPC WHERE CONVERT(VARCHAR, ComputerName) = '" & ComputerName & "'", connection)
            Dim OldPCCheckReader As SqlDataReader = OldPCCheckSQL.ExecuteReader()
            While OldPCCheckReader.Read()
                Exists = OldPCCheckReader("Count")
            End While
            connection.Close()
        End Using

        If Exists = "0" Then
            Me.Width = 694
            Me.Height = 527
            Me.pnlExisting.Hide()
            BackgroundWorkerADGrps.RunWorkerAsync()
            BackgroundWorkerPrinters.RunWorkerAsync()
            BackgroundWorkerGetOU.RunWorkerAsync()
            'Me.txtOldOU.Text = SystemChecks.Get_OU()
            Me.txtOldOU.ReadOnly = True
        Else
            Me.Width = 580
            Me.Height = 160
            Me.pnlExisting.Top = 3
            Me.pnlExisting.Left = 9
            'Me.txtOldOU.Text = SystemChecks.Get_OU()
            Me.pnlExisting.Show()
        End If
    End Sub
    ''################################ End  Process Old PC ################################
    '################################ Start Submit OLd PC ################################
    Private Sub btnSubmitOldPC_Click_1(sender As Object, e As EventArgs) Handles btnSubmitOldPC.Click
        OldHostname = ComputerName
        OldLocation = Me.txtLocation.Text
        OldCartSerial = Me.txtOldCartSerial.Text
        OldComputerADOU = Me.txtOldOU.Text
        OldPrinters = Me.txtOldPrinters.Text
        OldAdditionalNotes = Me.txtOldNotes.Text

        If Exists = "0" Then
            'Insert new record
            Using connection As New SqlConnection(conn)
                connection.Open()
                Dim OldPCInsertSQL As New SqlCommand("INSERT INTO OldPC (UserID, ComputerName, Location, CartSerial, ComputerOU, Printers, Notes, InProgress, Date) Values ('" & LoginID & "','" & ComputerName & "','" & OldLocation & "','" & OldCartSerial & "','" & OldComputerADOU & "','" & OldPrinters & "','" & OldAdditionalNotes & "','1', '" & today & "')", connection)
                Dim OldPCInsertReader As SqlDataReader = OldPCInsertSQL.ExecuteReader()
                While OldPCInsertReader.Read()
                    OldComputerName = OldPCInsertReader("ComputerName").ToString
                    OldPCID = OldPCInsertReader("id").ToString
                End While
                connection.Close()
            End Using
            'Me.txtLocation.Clear()
            'Me.txtOldCartSerial.Clear()
            'Me.txtOldOU.Clear()
            'Me.lbxOldPrinters.Clear()
            'Me.txtOldNotes.Clear()
            MsgBox("New Computer Documentation has been uploaded", MsgBoxStyle.Information)
            Me.Close()
        ElseIf Exists = "Replace" Then
            'Delete Existing
            Using connection As New SqlConnection(conn)
                connection.Open()
                Dim OldPCInsertSQL As New SqlCommand("DELETE FROM OldPC WHERE CONVERT(VARCHAR, ComputerName) = '" & ComputerName & "'", connection)
                Dim OldPCInsertReader As SqlDataReader = OldPCInsertSQL.ExecuteReader()
                While OldPCInsertReader.Read()
                    OldComputerName = OldPCInsertReader("ComputerName").ToString
                    OldPCID = OldPCInsertReader("id").ToString
                End While
                connection.Close()
            End Using
            'Replace Existing Record
            Using connection As New SqlConnection(conn)
                connection.Open()
                Dim OldPCInsertSQL As New SqlCommand("INSERT INTO OldPC (UserID, ComputerName, Location, CartSerial, ComputerOU, Printers, Notes, InProgress, Date) Values ('" & LoginID & "','" & ComputerName & "','" & OldLocation & "','" & OldCartSerial & "','" & OldComputerADOU & "','" & OldPrinters & "','" & OldAdditionalNotes & "','1', '" & today & "')", connection)
                Dim OldPCInsertReader As SqlDataReader = OldPCInsertSQL.ExecuteReader()
                While OldPCInsertReader.Read()
                    OldComputerName = OldPCInsertReader("ComputerName").ToString
                    OldPCID = OldPCInsertReader("id").ToString
                End While
                connection.Close()
            End Using
            'Me.txtLocation.Clear()
            'Me.txtOldCartSerial.Clear()
            'Me.txtOldOU.Clear()
            'Me.lbxOldPrinters.Clear()
            'Me.txtOldNotes.Clear()
            MsgBox("Replaced existing computer documentation", MsgBoxStyle.Information)
            Me.Close()
        ElseIf Exists = "Update" Then
            'Update Existing Record
            Using connection As New SqlConnection(conn)
                connection.Open()
                Dim OldPCInsertSQL As New SqlCommand("UPDATE OldPC SET UserID = '" & LoginID & "', ComputerName = '" & ComputerName & "', Location = '" & OldLocation & "', CartSerial = '" & OldCartSerial & "', ComputerOU = '" & OldComputerADOU & "', Printers = '" & OldPrinters & "', Notes = '" & OldAdditionalNotes & "', InProgress = '1', Date = '" & today & "' WHERE CONVERT(VARCHAR, ComputerName) = '" & ComputerName & "'", connection)
                Dim OldPCInsertReader As SqlDataReader = OldPCInsertSQL.ExecuteReader()
                While OldPCInsertReader.Read()
                    OldComputerName = OldPCInsertReader("ComputerName").ToString
                    OldPCID = OldPCInsertReader("id").ToString
                End While
                connection.Close()
            End Using
            'Me.txtLocation.Clear()
            'Me.txtOldCartSerial.Clear()
            'Me.txtOldOU.Clear()
            'Me.lbxOldPrinters.Clear()
            'Me.txtOldNotes.Clear()
            MsgBox("Updated existing computer documentation", MsgBoxStyle.Information)
            Me.Close()
            Form1.Show()
        End If
    End Sub
    '################################ End Submit OLd PC ################################
    '################################ Start Cancel Old PC ################################
    Private Sub btnCancelOldPC_Click(sender As Object, e As EventArgs) Handles btnCancelOldPC.Click
        Me.Close()
        Form1.Show()
    End Sub
    Private Sub btnExistsCancel_Click(sender As Object, e As EventArgs) Handles btnExistsCancel.Click
        Me.Close()
        Form1.Show()
    End Sub
    '################################ End Cancel Old PC ################################
    '################################ Start Fresh Start Process on  PC ################################
    Private Sub btnExistingFresh_Click(sender As Object, e As EventArgs) Handles btnExistingFresh.Click
        Me.pnlExisting.Hide()
        Exists = "Replace"
        BackgroundWorkerADGrps.RunWorkerAsync()
        BackgroundWorkerPrinters.RunWorkerAsync()
        BackgroundWorkerGetOU.RunWorkerAsync()
        Me.Width = 694
        Me.Height = 527
    End Sub
    '################################ End Fresh Start Process on  PC ################################
    '################################ Start Existing Modify PC ################################
    Private Sub btnExistsModify_Click(sender As Object, e As EventArgs) Handles btnExistsModify.Click
        Me.pnlExisting.Hide()
        Exists = "Update"
        Me.Width = 694
        Me.Height = 527
        ComputerName = System.Net.Dns.GetHostName
        Try

            Using connection As New SqlConnection(conn)
                connection.Open()
                Dim GetModifySQL As New SqlCommand("SELECT * FROM OldPC WHERE CONVERT(VARCHAR, ComputerName) = '" & ComputerName & "'", connection)
                Dim GetModifyReader As SqlDataReader = GetModifySQL.ExecuteReader()
                While GetModifyReader.Read()
                    Me.txtOldCartSerial.Text = GetModifyReader("CartSerial").ToString
                    Me.txtLocation.Text = GetModifyReader("Location").ToString
                    Me.txtOldOU.Text = GetModifyReader("ComputerOU").ToString
                    Me.txtOldPrinters.Text = GetModifyReader("Printers").ToString
                    Me.txtOldNotes.Text = GetModifyReader("Notes").ToString
                End While
                connection.Close()
            End Using

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmOldPC_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form1.Show()
    End Sub
    '################################ End Existing Modify PC ################################



    '########################################################################################
    '                                Background Workers
    '########################################################################################

    Private Sub BackgroundWorkerADGrps_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerADGrps.DoWork

        Try
            Dim output As String = ""

            'Dim script As String = "& gpresult /SCOPE computer /R"
            Dim script As String = "$error.Clear();
                                    $membership = @();

                                    try 
                                    {
                                        $Search = New-Object DirectoryServices.DirectorySearcher('(&(objectCategory=computer)(name='+$env:COMPUTERNAME+'))');
                                        $Results = $Search.FindAll();
                                        $Groups = $Results.Properties['MemberOf'];

                                        foreach($grp in $Groups)
                                        {
                                            $grpname = $grp.Replace('CN=','');
                                            $grpname = $grpname.Substring(0,$grpname.IndexOf(','));

                                            $membership += $grpname;
                                        }
                                    }
                                    catch
                                    {
                                        #throw $error.GetEnumerator();
                                    }

                                    $membership;"

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

            If errors.Length > 0 Then
                MsgBox(errors, MsgBoxStyle.Critical)
            Else
                If scriptoutput.Length < 1 Then
                    output = "No AD Group Memebership Found"
                Else
                    output = "AD Group Memebership" + Environment.NewLine + scriptoutput
                End If
            End If

            e.Result = output

        Catch ex As Exception
            MsgBox("AD Groups Error    " & ex.ToString(), MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BackgroundWorkerADGrps_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerADGrps.RunWorkerCompleted
        Me.txtOldNotes.Text += e.Result.ToString()
    End Sub

    Private Sub BackgroundWorkerPrinters_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerPrinters.DoWork
        Try
            Dim strPrinter$
            Dim strPrinterPN$
            Dim strPrinterN
            Dim objWMIService As Object
            Dim objPrinters As Object
            Dim objPrinter As Object
            Dim Output As String = ""
            objWMIService = GetObject("winmgmts:\\.\root\cimv2")
            objPrinters = objWMIService.ExecQuery("Select * From Win32_Printer")

            For Each objPrinter In objPrinters
                If objPrinter.Name Like "*OneNote*" Or objPrinter.Name Like "*XPS*" Or objPrinter.Name Like "*PDF*" Or objPrinter.Name Like "*Fax*" Or objPrinter.Name Like "*WebEx*" Then

                Else
                    strPrinter = objPrinter.Name
                    strPrinterPN = objPrinter.DriverName
                    strPrinterN = objPrinter.Portname
                    Output += "Name: " & strPrinter & vbCrLf & "Driver Name: " & strPrinterPN & vbCrLf & "Port Name: " & strPrinterN & vbCrLf & vbCrLf
                End If
            Next


            e.Result = Output
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BackgroundWorkerPrinters_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerPrinters.RunWorkerCompleted
        Me.txtOldPrinters.Text += e.Result.ToString()
    End Sub

    Private Sub BackgroundWorkerGetOU_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerGetOU.DoWork
        Try
            Dim output As String = ""

            'Dim script As String = "& gpresult /SCOPE computer /R"
            Dim script As String = "$Error.Clear();
                                    try
                                    {
                                        $pcname = $env:COMPUTERNAME;
    
                                        $GPOUFind = Get-ItemProperty 'HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Group Policy\State\Machine' -Name 'Distinguished-Name';
                                        $OUDN = $GPOUFind.'Distinguished-Name';
                                        $OUDN = $OUDN.Replace(',DC=org','.org');
                                        $OUDN = $OUDN.Replace(',DC=com','.com');
                                        $OUDN = $OUDN.Replace(',DC=net','.net');
                                        $OUDN = $OUDN.Replace(',DC=','\');
                                        $OUDN = $OUDN.Replace(',CN=','\');
                                        $OUDN = $OUDN.Replace(',OU=','\');
                                        $OUDN = $OUDN.Replace('CN=' + $pcname + '\','');
                                    }
                                    catch
                                    {
                                        
                                    }
                                    $OUDN;"

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

            If errors.Length > 0 Then
                MsgBox(errors, MsgBoxStyle.Critical)
            Else
                If scriptoutput.Length < 1 Then
                    output = "No Printers Found"
                Else
                    output = scriptoutput
                End If
            End If

            e.Result = output

        Catch ex As Exception
            MsgBox("OU Error      " & ex.ToString(), MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BackgroundWorkerGetOU_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerGetOU.RunWorkerCompleted
        Me.txtOldOU.Text = e.Result.ToString()
    End Sub
End Class