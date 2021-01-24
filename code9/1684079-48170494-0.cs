    using System.Diagnostics;
    
    namespace ConsoleApplication2
    {
     class Program
     {
      static void Main(string[] args)
      {
       Process myProcess = new Process();
    
       myProcess.StartInfo.FileName = @"ConsoleApplication1.exe";
       myProcess.StartInfo.UseShellExecute = false;
       myProcess.StartInfo.RedirectStandardOutput = true;
       myProcess.StartInfo.RedirectStandardInput = true;
    
       myProcess.Start();
    
       string redirectedOutput=string.Empty;
       while ((redirectedOutput += (char)myProcess.StandardOutput.Read()) != "Enter File Name:") ;
    
       myProcess.StandardInput.WriteLine("passedFileName.txt");
    
       myProcess.WaitForExit();
    
       //verifying that the job was successfull or not?!
       Process.Start("explorer.exe", "passedFileName.txt");
      }
     }
    }
