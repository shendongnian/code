    public bool ThreadStatus = true;
    static Thread thread;
    public void Run()
    {
        while (ThreadStatus)
        {
            Thread.Sleep(2000);
            Process[] nProcess = Process.GetProcessesByName(processName);
            if (nProcess.Length > 0)
            {
                if (!nProcess[0].HasExited && ThreadStatus == true)
                {
                    nProcess[0].Kill();
                }
            }
        }
        thread.Join();
    }
    public void StartThread()
    {
        thread = new Thread(new ThreadStart(this.Run));
        thread.Start();
    }
