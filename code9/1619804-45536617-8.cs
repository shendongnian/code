    private void BindProcesses()
    {
        foreach (var process in this.GetRunning())
        {
            process.EnableRaisingEvents = true;
            process.Exited += this.HandleClosed;
        }
    }
