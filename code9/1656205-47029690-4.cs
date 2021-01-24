    [System.STAThread]
    static void Main(string[] args)
    {
        foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
        {
            if (p.MainModule.FileName.EndsWith("bla.exe", System.StringComparison.CurrentCultureIgnoreCase))
                return;
        }
        [...]
    }
