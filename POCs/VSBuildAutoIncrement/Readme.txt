+--+   +--+
|  |   |  |
|  |   |  | +--+
|  +---+  | |  |
|         | +--+
|  +---+  | +--+
|  |   |  | |  |
|  |   |  | |  |
+--+   +--+ +--+

01. Copy DevTools content in a folder where you have your development tools.
02. Copy content of Example folder where you have your test/example/POC projects.
03. The content of Example folder has AutoIncrementBuild.sln file. Double click to open in VS.
04. In VS, open project properties and go to "Build Events" Tab.
05. Look at the field Post-build event command line:. It contains a path "J:\Demo\DevTools\AutoBuild\".
06. Replace aforesaid path with the path where you placed the content of the DevTools. do not forget to include drive letter and complete path.
07. Go to this example project's folder and open BuildLog.txt file.
08. Check you have header lines only in the file. close the file.
09. Come back to VS and F6-compile, the project we opened in the steps above.
10. Confirm the Build>Output window for build success message and other messages from the auto-increment script.
11. Open BuldLog.txt file and you should find the entry of the latest build.
12. You can make some important adjustments to how build number is incremented. To know more visit blog post:
       - https://sharpsnippets.wordpress.com/2013/10/13/auto-increment-builds-part-1/


Thanks
Sanjay Sharma
21:52 Oct 15, 2013

PilcrowApps.com
twitter: @SanjayAtPilcrow
facebook: facebook/sanjay.sharma.ind