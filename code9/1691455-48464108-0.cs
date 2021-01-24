    public string GetProcessPath(string name)
    {
        Process[] processes = Process.GetProcessesByName(name);
    
        if (processes.Length > 0)
        {
            return processes[0].MainModule.FileName;
        }
        else
        {
            return string.Empty;
        }
    }
