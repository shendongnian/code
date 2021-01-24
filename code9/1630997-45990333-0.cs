    Process process = new Process();
    
    try
    {
        process.StartInfo.FileInfo = "C:\\MyProgram.exe";
        process.Start();
    }
    catch (Exception e)
    {
        Debug.Log(e.Message);
    }
