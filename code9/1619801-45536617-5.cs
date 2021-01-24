    private void BindProcesses()
    {
        foreach (var process in this.GetRunning())
        {
            process.Exited += this.HandleClosed;
        }
    }
