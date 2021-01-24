    public bool isInDesignMode()
    {
        System.Diagnostics.Process process = System.Diagnostics.Process.GetCurrentProcess();
        bool res = process.ProcessName == "devenv";
        process.Dispose();
        return res;
    }
