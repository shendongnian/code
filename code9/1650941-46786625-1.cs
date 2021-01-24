    private ManualResetEvent runningWork = new ManualResetEvent(true);
    public void Main()
    {
        //
        
        // suspend
        runningWork.Reset();
        // resume
        runningWork.Set();
        //
    }
    public void Work()
    {
        // long task
        while (!stop)
        {
            runningWork.WaitOne(/* optional timeout */);
            //worker task
        }
    }
