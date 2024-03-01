Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO
Imports System.Deployment.Application

Public Class Form1
    '################################ Start Declare Public Variables ################################
    Public Shared LoggedIn As String = 0
    Public Shared LoginID As String
    Public Shared UserFName As String
    Public Shared UserLName As String
    Public Shared UserPermissions As String
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
    Public Shared today As DateTime = DateTime.Now
    Public Shared successconnection As String = 0
    Public Shared AppVersion = Application.ProductVersion
    '################################ End Declare Public Variables ################################


    '################################ Start Login Process ################################
    Private Sub LoginProcess()
        LoginID = Me.txtLoginID.Text
        'Check for existing user in the database

        Try
            Using connection As New SqlConnection(conn)
                connection.Open()
                connection.Close()
                successconnection = 1
            End Using
        Catch ex As Exception
            MsgBox("Can not connect to the database at this time", MsgBoxStyle.Critical)
        End Try

        If successconnection = "1" Then
            Using connection As New SqlConnection(conn)
                connection.Open()

                Dim LoginSQL As New SqlCommand("SELECT COUNT(*) as Count FROM USERS WHERE UserID = '" & LoginID & "'", connection)
                Dim LoginReader As SqlDataReader = LoginSQL.ExecuteReader()

                While LoginReader.Read()
                    LoginCount = LoginReader("Count").ToString
                End While

                connection.Close()
            End Using

            If LoginCount = 0 Then
                MsgBox("Incorrect Login ID", MsgBoxStyle.Critical)
                Me.txtLoginID.Text = ""
            Else
                'Get Users Name Information
                Using connection As New SqlConnection(conn)
                    connection.Open()
                    Dim LoginNameSQL As New SqlCommand("SELECT * FROM USERS WHERE UserID = '" & LoginID & "'", connection)
                    Dim LoginReader As SqlDataReader = LoginNameSQL.ExecuteReader()
                    While LoginReader.Read()
                        UserFName = LoginReader("FName").ToString
                        UserLName = LoginReader("LName").ToString
                        UserPermissions = LoginReader("UserPermissions").ToString
                    End While
                    connection.Close()
                End Using
                If UserPermissions = 2 Or UserPermissions = 3 Then
                    'set the Logged In flag for future use
                    LoggedIn = 1
                    Me.txtLoginID.Text = ""
                    pnlLogin.Visible = False
                    btnLogout.Visible = True
                    pnlStartPage.Visible = True
                    Me.Height = 612
                    Me.Width = 732
                    pnlStartPage.Left = 15
                    pnlStartPage.Top = 66
                    Me.lblHello.Text = "Hello " & UserFName & " | " & LoginID
                    Call ComputerInProgress()
                Else
                    MsgBox("You do not have the appropriate rights to run this application. Please contact a member of Desktop Engineering to get this adjusted", MsgBoxStyle.MsgBoxHelp)
                End If
            End If
        End If
    End Sub
    '################################ End Login Process ################################


    '################################ Start PC In Process ################################
    Private Sub ComputerInProgress()

        Try

            Using connection As New SqlConnection(conn)
                connection.Open()
                Dim InProgressSQL As New SqlCommand("SELECT * FROM OldPC WHERE InProgress = 1 and UserID = '" & LoginID & "'", connection)
                Dim InProgressReader As SqlDataReader = InProgressSQL.ExecuteReader()
                While InProgressReader.Read()
                    OldComputerName = InProgressReader("ComputerName").ToString
                    OldPCID = InProgressReader("id").ToString

                    lbxComputerSelection.Items.Add(OldPCID & " | " & OldComputerName)
                End While
                connection.Close()
            End Using

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try

    End Sub
    '################################ End PC In Process ################################


    '################################ Start Form Load ################################
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim NewVersion As String

        pnlLogin.Visible = True
        btnLogout.Visible = False
        pnlStartPage.Visible = False
        Me.Height = 303
        Me.Width = 501
        pnlLogin.Left = 15
        pnlLogin.Top = 66
        Me.lblVersion.Text = "Version: " & AppVersion

        Try
            Using connection As New SqlConnection(conn)
                connection.Open()
                connection.Close()
                successconnection = 1
            End Using
        Catch ex As Exception
            MsgBox("Can not connect to the database at this time", MsgBoxStyle.Critical)
        End Try

        If successconnection = "1" Then
            Using connection As New SqlConnection(conn)
                connection.Open()

                Dim VersionSQL As New SqlCommand("SELECT Version FROM dbo.AppVersion", connection)
                Dim VersionReader As SqlDataReader = VersionSQL.ExecuteReader()

                While VersionReader.Read()
                    NewVersion = VersionReader("Version").ToString
                End While

                connection.Close()
            End Using
        End If

        If AppVersion.ToString < NewVersion Then
            MsgBox("There is a new version, " & NewVersion & ", of this executable out there. this new version has process inmprovments and should be updatetd. Please go to the share and download the latest version.", MsgBoxStyle.Exclamation)
        End If
    End Sub
    '################################ End Form Load ################################


    '################################ Start Login Page ################################
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Call LoginProcess()
    End Sub
    '################################ End Login Page ################################


    '################################ Start Start Page ################################
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Me.lbxComputerSelection.Items.Clear()
        Call ComputerInProgress()
    End Sub
    '################################ End Start Page ################################


    '################################ Start New PC Screen ################################
    Private Sub btnNewPC_Click(sender As Object, e As EventArgs) Handles btnNewPC.Click
        frmOldPC.Show()
        'Me.Visible = False
    End Sub
    '################################ End New PC Screen ################################


    '################################ Start Continue Replacement Screen ################################
    Private Sub btnContinueReplacement_Click(sender As Object, e As EventArgs) Handles btnContinueReplacement.Click

        Try
            If lbxComputerSelection.SelectedIndex >= 0 Then
                ContinueMachineName = lbxComputerSelection.SelectedItem.ToString()
                frmNewPC.Show()
                Me.Visible = False
            Else
                MsgBox("Must Select System to Continue!", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical)
        End Try

    End Sub
    '################################ End Continue Replacement Screen ################################


    '################################Start Logout################################
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        LoggedIn = 0
        btnLogout.Visible = False
        pnlLogin.Visible = True
        pnlStartPage.Visible = False
        Me.Height = 303
        Me.Width = 501
        pnlLogin.Left = 15
        pnlLogin.Top = 66
    End Sub
    '################################ End Logout ################################


    '################################ Start PIN Txtbox keydown event ################################
    Private Sub txtLoginID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLoginID.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call LoginProcess()
        End If
    End Sub

    Private Sub lbllnkWebPage_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbllnkWebPage.LinkClicked
        Process.Start("http://mdcoap104338/pcchecklist/index.php")
    End Sub
    '################################ End PIN Txtbox keydown event ################################
End Class