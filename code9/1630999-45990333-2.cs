    Process process = new Process();
    
    try
    {
        process.StartInfo.FileInfo = "C:\\MyProgram.exe";
        process.EnableRaisingEvents = true;
        process.Exited += (sender, e) => { /* Code executed on process exit */ };
        process.Start();
    }
    catch (Exception e)
    {
        Debug.Log(e.Message);
    }
