Imports System.IO

Module TestChecks

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

    'Trgger scripts
    Function GPO_Check() As String

        Try
            Dim output As String = ""

            'Dim script As String = "& gpresult /SCOPE computer /R"
            Dim script As String = "$Error.Clear();
                                    $gpresult = & cmd.exe /C gpresult /R; 
                                    $gpcontentsplit = $gpresult.Split([System.Environment]::NewLine);
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
                                            {$_ -like '*The user *does not have RSoP data*'}
                                                {
                                                    throw $gpcontentsplit[$lineIndex];
                                                }
                                        }
                                    }

                                    if($Error.Count -lt 1)
                                    {
                                        $returnstring = $appliedcomputervalues + '|' + $applieduservalues;
                                        $returnstring;
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

            Return output
        Catch ex As Exception
            Return ex.ToString()
        End Try

    End Function

    Function SCCM_Check() As String

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

                                        $CCMResultObj = New-Object System.Object
                                        $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'System' -Value $PCName;
                                        $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'Date_Created' -Value $CurrentDate;
                                        $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'CCM_WMI_Client_Check' -Value $CCMClientWMIChk;
                                        $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'CCM_Service_Check' -Value $CCMServiceChk;
                                        $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'CCM_Setup_Check' -Value $CCMSetupLogChk;
                                        $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'CCM_Log_Dir_Check' -Value $CCMLogCountChk;
                                        $CCMResultObj | Add-Member -MemberType NoteProperty -Name 'CCM_Overall_Check' -Value $CCMOverallChk;
                                    }
                                    catch
                                    {
                                        $Error.GetEnumerator()
                                    }

                                    if($Error.Count -gt 0)
                                    {
                                        $Error.GetEnumerator()
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

            Return output
        Catch ex As Exception
            Return ex.ToString()
        End Try

    End Function

    Function Network_Check() As String
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
                                        }
                                    } 
                                    catch 
                                    {
    
                                    }

                                    $result = $webreqresult + [System.Environment]::NewLine + [System.Environment]::NewLine + $netadaptresult;

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

            Return output
        Catch ex As Exception
            Return ex.ToString()
        End Try
    End Function

End Module