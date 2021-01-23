    static void mapDrive(String driveChar, string server,string user, string password){
    
        try
        {               
            ProcessStartInfo procStartInfo;
            procStartInfo=new ProcessStartInfo();
            procStartInfo.FileName = @"C:\windows\system32\cmd.exe";
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.RedirectStandardError = true;
            procStartInfo.RedirectStandardInput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
    
            Process proc = new Process();
            proc.StartInfo = procStartInfo;
            proc.ErrorDataReceived += cmd_Error;
            proc.OutputDataReceived += cmd_DataReceived;
            proc.EnableRaisingEvents = true;
            proc.Start();
            proc.BeginOutputReadLine();
            proc.BeginErrorReadLine();
    
            proc.StandardInput.WriteLine(" if exist v: (echo true) else (echo false)");
            //it should print 'false'
            proc.WaitForExit();     
    
        }
        catch (Exception e)
        {
            // MessageBox.Show(e.Message);
        }
    }
    
    static void cmd_DataReceived(object sender, DataReceivedEventArgs e)
    {
        Console.WriteLine("Output from other process");
        Console.WriteLine(e.Data);
    }
    
    static void cmd_Error(object sender, DataReceivedEventArgs e)
    {
        Console.WriteLine("Error from other process");
        Console.WriteLine(e.Data);
    }
