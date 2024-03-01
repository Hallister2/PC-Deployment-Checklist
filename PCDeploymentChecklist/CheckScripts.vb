Imports System.IO

Module SystemChecks

    'Read_It - Function to gather content from file (Returns String)
    Function Read_It(ByVal strFileName As String) As String

        Dim RootDir As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
        Dim strPath As String = RootDir.Replace("file:\", "")
        Dim strContent As String = File.ReadAllText(strPath + "\" + strFileName)

        Return strContent

    End Function

    'Trigger_ps1 - Function to trigger local ps1 files
    Function Trigger_ps1(ByVal ps1file As String) As String

        Dim proc As New ProcessStartInfo
        Dim retresult As String

        Try

            proc.FileName = "cmd.exe"
            proc.Arguments = "/C powershell.exe -file " + ps1file
            proc.WindowStyle = ProcessWindowStyle.Hidden

            Process.Start(proc).WaitForExit()

            retresult = "Complete"

        Catch ex As Exception

            retresult = ex.ToString()

        End Try

        Return retresult

    End Function

    Function Trigger_EPO() As String
        Try
            Dim output As String = ""

            'Dim script As String = "& gpresult /SCOPE computer /R"
            Dim script As String = "$Error.Clear();
                                    $namespace = 'root\ccm\ClientSDK';
                                    $class = 'CCM_Application';

                                    try
                                    {
                                        $appinfo = Get-CimInstance -Namespace $namespace -ClassName $class | Where-Object{$_.FullName -like '*Notepad*'};

                                        foreach($app in $appinfo)
                                        {
                                            $installstate = $app.InstallState;
                                            $triggermethod = 'Install';
                                            $installargs = @{EnforcePreference = [UINT32]0
                                                            Id = $($app.Id)
                                                            IsMachineTarget = $($app.IsMachineTarget)
                                                            Priority = 'High'
                                                            Revision = $($app.Revision)
                                                            };

                                            switch ($installstate)
                                            {
                                                {$_ -eq 'Installed'}
                                                    {
                                                        $returnvalue = 'True,Good';
                                                    }
                                                {$_ -eq 'NotInstalled'}
                                                    {
                                                        $returnvalue = 'False,Trigger';
                                                        Invoke-CimMethod -Namespace $namespace -ClassName $class -MethodName $triggermethod -Arguments $installargs;
                                                    }
                                                {$_ -eq 'Unknown' -or $_ -eq 'Error'}
                                                    {
                                                        $returnvalue = 'False,Error';
                                                    }
                                                {$_ -eq 'NotEvaluated' -or $_ -eq 'NotUpdated' -or $_ -eq 'NotConfigured'}
                                                    {
                                                        $returnvalue = 'False,Evaluate';
                                                    }
                                            }
                                        }
                                    }
                                    catch
                                    {
                                        throw $Error.GetEnumerator();
                                    }

                                    $returnvalue;"

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

            If scriptoutput.Length < 1 Then
                output += "No Printers Found" + Environment.NewLine
            Else
                output += scriptoutput + Environment.NewLine
            End If

            output += Environment.NewLine
            output += "Errors:" + Environment.NewLine
            output += errors + Environment.NewLine

            Return output
        Catch ex As Exception
            Return ex.ToString()
        End Try
    End Function

    ' All commented out Functions from previous process

    'Function Get_OU() As String
    '    Try
    '        Dim output As String = ""

    '        'Dim script As String = "& gpresult /SCOPE computer /R"
    '        Dim script As String = "$Error.Clear();
    '                                try
    '                                {
    '                                    $pcname = $env:COMPUTERNAME;

    '                                    $GPOUFind = Get-ItemProperty 'HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Group Policy\State\Machine' -Name 'Distinguished-Name';
    '                                    $OUDN = $GPOUFind.'Distinguished-Name';
    '                                    $OUDN = $OUDN.Replace(',DC=org','.org');
    '                                    $OUDN = $OUDN.Replace(',DC=com','.com');
    '                                    $OUDN = $OUDN.Replace(',DC=net','.net');
    '                                    $OUDN = $OUDN.Replace(',DC=','\');
    '                                    $OUDN = $OUDN.Replace(',CN=','\');
    '                                    $OUDN = $OUDN.Replace(',OU=','\');
    '                                    $OUDN = $OUDN.Replace('CN=' + $pcname + '\','');
    '                                }
    '                                catch
    '                                {
    '                                    throw $Error.GetEnumerator();
    '                                }
    '                                $OUDN;"

    '        Dim objProcess As New System.Diagnostics.Process()

    '        objProcess.StartInfo.FileName = "powershell.exe"
    '        objProcess.StartInfo.Arguments = script
    '        objProcess.StartInfo.RedirectStandardOutput = True
    '        objProcess.StartInfo.RedirectStandardError = True
    '        objProcess.StartInfo.UseShellExecute = False
    '        objProcess.StartInfo.CreateNoWindow = True
    '        objProcess.Start()

    '        Dim scriptoutput As String = objProcess.StandardOutput.ReadToEnd()
    '        Dim errors As String = objProcess.StandardError.ReadToEnd()

    '        If errors.Length > 0 Then
    '            MsgBox(errors, MsgBoxStyle.Critical)
    '        Else
    '            If scriptoutput.Length < 1 Then
    '                output = "No Printers Found"
    '            Else
    '                output = scriptoutput
    '            End If
    '        End If

    '        Return output
    '    Catch ex As Exception
    '        Return ex.ToString()
    '    End Try
    'End Function

    'Function Get_ADMembership() As String
    '    Try
    '        Dim output As String = ""

    '        'Dim script As String = "& gpresult /SCOPE computer /R"
    '        Dim script As String = "$error.Clear();
    '                                $membership = @();

    '                                try 
    '                                {
    '                                    $Search = New-Object DirectoryServices.DirectorySearcher('(&(objectCategory=computer)(name='+$env:COMPUTERNAME+'))');
    '                                    $Results = $Search.FindAll();
    '                                    $Groups = $Results.Properties['MemberOf'];

    '                                    foreach($grp in $Groups)
    '                                    {
    '                                        $grpname = $grp.Replace('CN=','');
    '                                        $grpname = $grpname.Substring(0,$grpname.IndexOf(','));

    '                                        $membership += $grpname;
    '                                    }
    '                                }
    '                                catch
    '                                {
    '                                    throw $error.GetEnumerator();
    '                                }

    '                                $membership;"

    '        Dim objProcess As New System.Diagnostics.Process()

    '        objProcess.StartInfo.FileName = "powershell.exe"
    '        objProcess.StartInfo.Arguments = script
    '        objProcess.StartInfo.RedirectStandardOutput = True
    '        objProcess.StartInfo.RedirectStandardError = True
    '        objProcess.StartInfo.UseShellExecute = False
    '        objProcess.StartInfo.CreateNoWindow = True
    '        objProcess.Start()

    '        Dim scriptoutput As String = objProcess.StandardOutput.ReadToEnd()
    '        Dim errors As String = objProcess.StandardError.ReadToEnd()

    '        If errors.Length > 0 Then
    '            MsgBox(errors, MsgBoxStyle.Critical)
    '        Else
    '            If scriptoutput.Length < 1 Then
    '                output = "No AD Group Memebership Found"
    '            Else
    '                output = "AD Group Memebership" + Environment.NewLine + scriptoutput
    '            End If
    '        End If

    '        frmOldPC.adgroups = output

    '        'frmOldPC.txtOldNotes.Text += output
    '        'frmOldPC.txtOldNotes.Refresh()
    '        MsgBox(output, MsgBoxStyle.Critical)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString(), MsgBoxStyle.Critical)
    '    End Try
    'End Function

    'Function Gather_Printers() As String
    '    Try
    '        Dim output As String = ""

    '        'Dim script As String = "& gpresult /SCOPE computer /R"
    '        Dim script As String = "$Error.Clear();
    '                                $HKUlist = @();
    '                                $HKURevised = @();
    '                                $HKUConnections = @();
    '                                #$PrinterConnections = @();
    '                                #$PrinterLocals = @();
    '                                $output = @();

    '                                try 
    '                                {
    '                                    $location = Get-Location;
    '                                    $locationpath = $location.Path;

    '                                    if($locationpath -ne 'HKU:\')
    '                                    {
    '                                        Set-Location Registry::\HKEY_USERS;
    '                                        New-PSDrive HKU Registry HKEY_USERS -ErrorAction SilentlyContinue | Out-Null;
    '                                        Set-Location HKU:\;
    '                                    }

    '                                    $HKUlist = Get-ChildItem;

    '                                    foreach($hkuitem in $HKUlist)
    '                                    {
    '                                        $hkuname = $hkuitem.Name;

    '                                        if(($hkuname.Length -gt 20 -and $hkuname -notlike '*_Classes*') -or $hkuname -like '*Default*')
    '                                        {
    '                                            $HKURevised += $hkuname.Replace('HKEY_USERS\','');
    '                                        }
    '                                    }

    '                                    foreach($hkcuuser in $HKURevised)
    '                                    {
    '                                        $HKUConnections = Get-ChildItem -Path $hkcuuser\Printers\Connections -ErrorAction SilentlyContinue; 

    '                                        foreach($hkuconn in $HKUConnections)
    '                                        {
    '                                            $printername = $hkuconn.Name;
    '                                            $printername = $printername.Substring($printername.LastIndexOf(',') + 1, $printername.Length - $printername.LastIndexOf(',') - 1);

    '                                            $printerprops = Get-ItemProperty -Path $hkuconn.Name | Select-Object Server;
    '                                            $printerserver = $printerprops.Server;

    '                                            #$PrinterConnections += New-Object psobject -Property @{Name=$printername;Server=$printerserver}; 
    '                                            $output += 'Name='+$printername+'; Server='+$printerserver+'; Type=Connection';
    '                                        }
    '                                    }

    '                                    Remove-PSDrive HKU -Force -ErrorAction SilentlyContinue;

    '                                    Set-Location HKLM:\;

    '                                    $localprinters = Get-ChildItem HKLM:\SYSTEM\CurrentControlSet\Control\Print\Printers;

    '                                    foreach($lp in $localprinters)
    '                                    {
    '                                        $lpname = $lp.Name.Replace('C:\HKEY_LOCAL_MACHINE','HKLM:');
    '                                        $lpprops = Get-ItemProperty $lpname | Select-Object Name,Port,'Printer Driver';
    '                                        $lpoutname = $lpprops.Name;
    '                                        $lpoutport = $lpprops.Port;
    '                                        $lpoutdriver = $lpprops.'Printer Driver';

    '                                        #$PrinterLocals += New-Object psobject -Property @{Name=$lpoutname;Port=$lpoutport;PrintDriver=$lpoutdriver};
    '                                        $output += 'Name='+$lpoutname+'; Port:Driver='+$lpoutport+':'+$lpoutdriver+'; Type=Local'
    '                                    }

    '                                    Set-Location C:\;
    '                                }
    '                                catch
    '                                {
    '                                    throw $Error.GetEnumerator();
    '                                }

    '                                #$prntconn = $PrinterConnections | Select-Object Name,Server | Format-Table -Wrap -AutoSize | Out-String; 
    '                                #$prntlocal = $PrinterLocals | Select-Object Name,Port,PrintDriver | Format-Table -Wrap -AutoSize | Out-String;
    '                                #$output = 'Mapped Printers:' + [System.Environment]::NewLine + $prntconn + [System.Environment]::NewLine + 'Local Printers:' + [System.Environment]::NewLine + $prntlocal;

    '                                $output;"

    '        Dim objProcess As New System.Diagnostics.Process()

    '        objProcess.StartInfo.FileName = "powershell.exe"
    '        objProcess.StartInfo.Arguments = script
    '        objProcess.StartInfo.RedirectStandardOutput = True
    '        objProcess.StartInfo.RedirectStandardError = True
    '        objProcess.StartInfo.UseShellExecute = False
    '        objProcess.StartInfo.CreateNoWindow = True
    '        objProcess.Start()

    '        Dim scriptoutput As String = objProcess.StandardOutput.ReadToEnd()
    '        Dim errors As String = objProcess.StandardError.ReadToEnd()

    '        If errors.Length > 0 Then
    '            MsgBox(errors, MsgBoxStyle.Critical)
    '        Else
    '            If scriptoutput.Length < 1 Then
    '                output = "No Printers Found"
    '            Else
    '                output += scriptoutput
    '            End If
    '        End If

    '        Return output
    '    Catch ex As Exception
    '        Return ex.ToString()
    '    End Try
    'End Function
    'Trgger scripts
    'Function GPO_Check() As String

    '    Try
    '        Dim output As String = ""

    '        'Dim script As String = "& gpresult /SCOPE computer /R"
    '        Dim script As String = "$Error.Clear();
    '                                $gpresult = & cmd.exe /C gpresult /R; 
    '                                $gpcontentsplit = $gpresult.Split([System.Environment]::NewLine);
    '                                $lineIndex = 0;
    '                                [array]$result = @();
    '                                [array]$computerresult = @();
    '                                [array]$userresult = @();
    '                                [array]$applieduservalues = @('USER');
    '                                [array]$appliedcomputervalues = @('COMPUTER');

    '                                $result += 'System: ' + $PCName;
    '                                $result += 'Date_Created: ' + $CurrentDate;

    '                                [array]$computerresult = @();
    '                                [array]$userresult = @();
    '                                $computerresult = $false;
    '                                $userresult = $false;

    '                                foreach($line in $gpcontentsplit)
    '                                {
    '                                    $lineIndex += 1;

    '                                    switch($line)
    '                                    {
    '                                        {$_ -like '*COMPUTER SETTINGS*' -or $computersection -eq $true}
    '                                            {
    '                                                $computersection = $true;
    '                                                $userresult = $false;

    '                                                    if($gpcontentsplit[$lineIndex] -like '*Applied Group Policy Objects*' -or $appliedcomputerpolicies -eq $true)
    '                                                    {
    '                                                        $appliedcomputerpolicies = $true;
    '                                                        $appliedcomputervalues += $gpcontentsplit[$lineIndex-1];

    '                                                        if($gpcontentsplit[$lineIndex] -eq '')
    '                                                        {
    '                                                            $appliedcomputerpolicies = $false;  
    '                                                            $appliedcomputerpolicies = $false;
    '                                                        }
    '                                                    }
    '                                                    else
    '                                                    {
    '                                                        $computerresult += $gpcontentsplit[$lineIndex-1];
    '                                                    }
    '                                            }
    '                                        {$_ -like '*USER SETTINGS*' -or $userresult -eq $true}
    '                                            {
    '                                                $userresult = $true;
    '                                                $computersection = $false;

    '                                                    if($gpcontentsplit[$lineIndex] -like '*Applied Group Policy Objects*' -or $applieduserpolicies -eq $true)
    '                                                    {
    '                                                        $applieduserpolicies = $true;
    '                                                        $applieduservalues += $gpcontentsplit[$lineIndex-1];

    '                                                        if($gpcontentsplit[$lineIndex] -eq '')
    '                                                        {
    '                                                            $applieduserpolicies = $false;  
    '                                                            $applieduserpolicies = $false;
    '                                                        }
    '                                                    }
    '                                                    else
    '                                                    {
    '                                                        $userresult += $gpcontentsplit[$lineIndex-1];
    '                                                    }
    '                                            }
    '                                        {$_ -like '*The user *does not have RSoP data*'}
    '                                            {
    '                                                throw $gpcontentsplit[$lineIndex];
    '                                            }
    '                                    }
    '                                }

    '                                if($Error.Count -lt 1)
    '                                {
    '                                    $returnstring = $appliedcomputervalues + '|' + $applieduservalues;
    '                                    $returnstring;
    '                                }
    '                                else
    '                                { 
    '                                    throw $Error.GetEnumerator(); 
    '                                }"

    '        Dim objProcess As New System.Diagnostics.Process()

    '        objProcess.StartInfo.FileName = "powershell.exe"
    '        objProcess.StartInfo.Arguments = script
    '        objProcess.StartInfo.RedirectStandardOutput = True
    '        objProcess.StartInfo.RedirectStandardError = True
    '        objProcess.StartInfo.UseShellExecute = False
    '        objProcess.StartInfo.CreateNoWindow = True
    '        objProcess.Start()

    '        Dim scriptoutput As String = objProcess.StandardOutput.ReadToEnd()
    '        Dim errors As String = objProcess.StandardError.ReadToEnd()

    '        output += "Output:" + Environment.NewLine
    '        output += scriptoutput + Environment.NewLine
    '        output += Environment.NewLine
    '        output += "Errors:" + Environment.NewLine
    '        output += errors + Environment.NewLine

    '        Return output
    '    Catch ex As Exception
    '        Return ex.ToString()
    '    End Try

    'End Function
    'Function SCCM_Check() As String

    '    Try
    '        Dim output As String = ""
    '        Dim script As String = "$Error.Clear();
    '                                $PCName = $env:COMPUTERNAME;
    '                                $CurrentDate = Get-Date -Format 'yyyy-MM-dd';


    '                                try
    '                                {
    '                                    $CCMLogRoot = 'C:\Windows\ccm\Logs';
    '                                    $CCMSetupRoot = 'C:\Windows\ccmsetup\Logs';

    '                                    $CCMClientWMIChk = $false;
    '                                    $CCMSetupLogChk = $false;
    '                                    $CCMLogCountChk = $false;
    '                                    $CCMServiceChk = $false;
    '                                    $CCMOverallChk = $false;

    '                                    $CCMLogDir = Get-ChildItem $CCMLogRoot -Force;
    '                                    $CCMLogDirCount = $CCMLogDir.Count;
    '                                    $CCMSetupLog = $CCMSetupRoot + '\ccmsetup.log';
    '                                    $ccmsetupexitcode = Get-Content $CCMSetupLog -Tail 1 -Force; 

    '                                    $ClientWMI = Get-WmiObject -Namespace root\ccm -Class SMS_Client -ErrorAction SilentlyContinue;

    '                                    if($ClientWMI -and $ClientWMI.ClientType -eq 1)
    '                                    {
    '                                        $CCMClientWMIChk = $true;
    '                                    }

    '                                    if($ccmsetupexitcode -like '*CcmSetup is exiting with return code 0*')
    '                                    {
    '                                        $CCMSetupLogChk = $true;
    '                                    }

    '                                    if($CCMLogDirCount -gt 70)
    '                                    {
    '                                        $CCMLogCountChk = $true;
    '                                    }

    '                                    $ccmexecservice = Get-Service CcmExec -ErrorAction SilentlyContinue;

    '                                    if($ccmexecservice -and $ccmexecservice.Status -eq 'Running')
    '                                    {
    '                                        $CCMServiceChk = $true;
    '                                    }

    '                                    if($CCMServiceChk -eq $true -and $CCMSetupLogChk -eq $true -and $CCMLogCountChk -eq $true)
    '                                    {
    '                                        $CCMOverallChk = $true;
    '                                    }

    '                                    $CCMResultObj = New-Object System.Object
    '                                    $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'System' -Value $PCName;
    '                                    $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'Date_Created' -Value $CurrentDate;
    '                                    $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'CCM_WMI_Client_Check' -Value $CCMClientWMIChk;
    '                                    $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'CCM_Service_Check' -Value $CCMServiceChk;
    '                                    $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'CCM_Setup_Check' -Value $CCMSetupLogChk;
    '                                    $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'CCM_Log_Dir_Check' -Value $CCMLogCountChk;
    '                                    $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'CCM_Overall_Check' -Value $CCMOverallChk;
    '                                }
    '                                catch
    '                                {
    '                                    $Error.GetEnumerator(); 
    '                                }

    '                                if($Error.Count -gt 0)
    '                                {
    '                                    throw $Error.GetEnumerator().ToString(); 
    '                                }
    '                                else
    '                                {
    '                                    $CCMResultObj;
    '                                }"
    '        Dim objProcess As New System.Diagnostics.Process()

    '        objProcess.StartInfo.FileName = "powershell.exe"
    '        objProcess.StartInfo.Arguments = script
    '        objProcess.StartInfo.RedirectStandardOutput = True
    '        objProcess.StartInfo.RedirectStandardError = True
    '        objProcess.StartInfo.UseShellExecute = False
    '        objProcess.StartInfo.CreateNoWindow = True
    '        objProcess.Start()

    '        Dim scriptoutput As String = objProcess.StandardOutput.ReadToEnd()
    '        Dim errors As String = objProcess.StandardError.ReadToEnd()

    '        output += "Output:" + Environment.NewLine
    '        output += scriptoutput + Environment.NewLine
    '        output += Environment.NewLine
    '        output += "Errors:" + Environment.NewLine
    '        output += errors + Environment.NewLine

    '        Return output
    '    Catch ex As Exception
    '        Return ex.ToString()
    '    End Try

    'End Function
End Module