    /// pathToBat = bat file pathToBat
    /// arg = any required arguments
    /// envVar = name of environment variable
    public string GetEnvVariable(string pathToBat, string arg, string envVar)
    {
    
    List<string> data = new List<string>();
    
    data.Add("@ECHO OFF");
    /// >nul 2>&1 = to put all the output away.
    data.Add(String.Format("CALL \"{0}\" {1} >nul 2>&1", pathToBat.Trim(), arg.Trim()));
    data.Add(String.Format("ECHO %{0}%", envVar));
    
    /// Write the file
    string path = Path.Combine("env.bat");
    File.WriteAllLines(path, data);
    
    string execute = String.Format("/c \"{0}\"", path);
    
    return ExecuteProcess("cmd.exe", execute);
    }
    private string ExecuteProcess(string executable, string argument)
    {
    
    ProcessStartInfo processStartInfo = new ProcessStartInfo();
    Process process = new Process();
    
    StringBuilder output = new StringBuilder();
    AutoResetEvent outputWaitHandle = new AutoResetEvent(false);
    
    processStartInfo.UseShellExecute = false;
    processStartInfo.FileName = executable;
    processStartInfo.Arguments = command;
    processStartInfo.RedirectStandardOutput = true;
    
    process.StartInfo = processStartInfo;
    
    process.OutputDataReceived += (sender, e) =>
        {
        if (e.Data == null)
            outputWaitHandle.Set();
        else
            output.AppendLine(e.Data);
        };
    	
    bool stat = process.Start();
    process.BeginOutputReadLine();
    
    process.WaitForExit();
    int exitCode = process.ExitCode;
    
    if (exitCode == 0 && stat)
        {
            //Log.Debug("Command Executed successfully");
    		return output.ToString();
        }
    else
        {
            //Log.Debug("Command Failed");
    		return String.Empty;
        }	
    }
