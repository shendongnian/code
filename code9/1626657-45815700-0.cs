    ProcessStartInfo processStartInfo = new ProcessStartInfo
    {
        WindowStyle = ProcessWindowStyle.Hidden,
        FileName = zipFileExePath,
        Arguments = "x \"" + zipPath + "\" -o\"" + extractPath + "\""
    };
    
    using (Process process = Process.Start(processStartInfo))
    {
        if (process.WaitForExit(timeout))
        {
    		//somecode?
        }
        else
        {
            s_logger.ErrorFormat("Timeout whilte extracting extracting {0}", zipPath);
        }
    
        process.Kill();
    }
