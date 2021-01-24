    private List<Process> GetRunning()
    {
        return Process.GetProcesses().Where(p => !string.IsNullOrEmpty(p.MainWindowTitle)).ToList();
    }
    private void AddButtons()
    {
        for (var process in this.GetRunning())
        {
            AddBtn(process.ProcessName);
        }
    }
