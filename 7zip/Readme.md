######Introduction
7zip (http://www.7-zip.org/) is an archive utility. 7zip has a nice GUI to create basic archive but you need to switch to command line if you want to include/exclude folders. It is boring to type same command again and again if you have to take zipped backup periodically.

This little batch file creates password protected 7z archive of the specified folders in the folder where this batch file resides. You can also specify names of the folder you want to exclude from the archive. By default this archives - Source and doc folders, and excludes bin,obj, and temp/test folders.

######Usage
Copy backup.bat file in the folder which has the subfolders you want to archive. Navigate to the folder in explorer and open command prompt in the same folder. Type backup.bat at the command prompt and follow the instructions.

######Requirements
* 7zip (http://www.7-zip.org/)
* Powershell (Windows7 up, all versions have powershell by default)
* 7zip executable path in global path variable (start > advanced system settings > Advanced.Environment Veriables > PATH > include 7zip executable path, usually it is %PROGRAMFILES%\7ZIP;)

######Tweaks
Following is the default 7zip command in the batch file - 

`7z.exe a -t7z yyyymmddhhmm_filename.7z Docs source -mhe=on -p%password% -xr!bin -xr!obj -x!temp/test`

"Docs Source" specify the two folders - docs and source, to archive. You can add/change folders to include here. "-xr!bin -xr!obj -x!temp/test" specify 3 folders to exclude from archive - bin, obj, and temp/test. "r" switch in obj and bin denotes that bin and obj folder could be anywhere in the folder structure.
