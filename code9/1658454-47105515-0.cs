    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net.Mime;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace GetNetworkFullPath
    {
        class Program
        {
            static void Main(string[] args)
            {
                var networkFolder = "\\\\REMOTE-PC-NAME\\SharedFolder";
                var nameOfVBScript = "capturepath.vbs";
                var vbsOutput = "";
    
                //Get the name of the current directory
                var currentDirectory = Directory.GetCurrentDirectory();
                Console.WriteLine("Current Dir: " + currentDirectory);
    
    
                //1. CREATE A VBSCRIPT TO OUTPUT THE PATH WHERE IT IS PRESENT
                //Ref. https://stackoverflow.com/questions/2129327/how-to-get-the-fully-qualified-path-for-a-file-in-vbscript
                var vbscriptToExecute = "Dim folderName \n" +
                                            "folderName = \"\" \n" +
                                            "Dim fso \n" +
                                            "Set fso = CreateObject(\"Scripting.FileSystemObject\") \n" +
                                            "Dim fullpath \n" +
                                            "fullpath = fso.GetAbsolutePathName(folderName) \n" +
                                            "WScript.Echo fullpath \n";
    
    
                //Write that script into a file into the current directory
                System.IO.File.WriteAllText(@""+ nameOfVBScript  + "", vbscriptToExecute);
    
    
                //2. COPY THE CREATED SCRIPT INTO THE NETWORK PATH
                //Ref. https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-copy-delete-and-move-files-and-folders
                string sourceFile = System.IO.Path.Combine(currentDirectory, nameOfVBScript);
                string destFile = System.IO.Path.Combine(networkFolder, nameOfVBScript);
    
                System.IO.File.Copy(sourceFile, destFile, true);
    
                //3. EXECUTE THAT SCRIPT AND READ THE OUTPUT
                Process scriptProc = new Process();
                ProcessStartInfo info = new ProcessStartInfo();
                info.WorkingDirectory = @"" + networkFolder + "";
                info.FileName = "Cscript.exe";
                info.Arguments = nameOfVBScript;
                info.RedirectStandardError = true;
                info.RedirectStandardInput = true;
                info.RedirectStandardOutput = true;
                info.UseShellExecute = false;
                info.WindowStyle = ProcessWindowStyle.Hidden;
                scriptProc.StartInfo = info;
                scriptProc.Start();
                scriptProc.WaitForExit();
                bool exit = false;
    
                while (!scriptProc.StandardOutput.EndOfStream)
                {
                    vbsOutput = scriptProc.StandardOutput.ReadLine();
                }
    
                Console.WriteLine("vbscript says: " + vbsOutput);
    
    
                //4. DELETE THE FILE YOU JUST COPIED THERE
                System.IO.File.Delete(@"" + networkFolder + "\\" + nameOfVBScript);
            }
        }
    }
