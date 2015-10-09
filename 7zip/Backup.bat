echo off
REM .------------------------------------------------------------------------------------------------------------
REM : Author  : Sanjay Sharma
REM : Date    : 201510092141
REM : License : GPL
REM :
REM :------------------------------------------------------------------------------------------------------------
echo ====Quick archive utility=====
echo .----------------------------------------------------------
echo :          I   M  P  O  R  T  A  N  T
echo :----------------------------------------------------------
echo :     This only archives source and doc folder and excludes bin and obj folders, if they exist in source or doc.
echo :     For all folders in this directory, use BackupAll.bat
echo :     This guy always makes yyyymmddhhmm_Dhundhliya_S_D.7z in current folder. 
echo :            Change name and copy somewhere else or upload!
echo :     Run this from command prompt, not direclty from Windows Explorer!!!!!
echo :     Copy local archive in C:\Data\pilcrow\dhundhliya\bkps
echo :     Upload to OneDrive : SanjayKCSharma.live.in
echo :     
echo :     
echo :     
echo :--------------------------------------------------------------------
echo :    !!!!!! Wait till Enter Password prompt appears !!!!!
echo :--------------------------------------------------------------------
echo .
echo .
echo off
CALL:ECHORED " ----------------------------------------"
CALL:ECHORED ":          C A U T I O N                 :"
CALL:ECHORED ":     Confirm CAPS LOCK is off           :"
CALL:ECHORED " ========================================"


start /b /wait powershell.exe -nologo -sta -command "IF ([console]::CapsLock -eq 'True'){$wsh = New-Object -ComObject WScript.Shell;$wsh.SendKeys('{CAPSLOCK}')}"
powershell -Command $pword = read-host "Enter password" -AsSecureString ; $BSTR=[System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($pword) ; [System.Runtime.InteropServices.Marshal]::PtrToStringAuto($BSTR) > .tmp.txt & set /p password=<.tmp.txt & del .tmp.txt
powershell -Command $pword = read-host "Confirm" -AsSecureString ; $BSTR=[System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($pword) ; [System.Runtime.InteropServices.Marshal]::PtrToStringAuto($BSTR) > .tmp.txt & set /p password2=<.tmp.txt & del .tmp.txt

IF %password%==%password2% 7z.exe a -t7z yyyymmddhhmm_Dhundhliya_S_D.7z Docs source -mhe=on -p%password% -xr!bin -xr!obj -xr!werMain\platforms
IF NOT %password%==%password2% echo Password do not match
pause




:ECHORED
%Windir%\System32\WindowsPowerShell\v1.0\Powershell.exe write-host -foregroundcolor Red %1
goto:eof
