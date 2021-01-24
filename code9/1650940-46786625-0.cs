    private ManualResetEvent suspended = new ManualResetEvent(true);
    public void Main()
    {
        //
        
        // suspend
        suspended.Reset();
        // resume
        suspended.Set();
        //
    }
    public void Work()
    {
        // long task
        while (!stop)
        {
            suspended.WaitOne(/* optional timeout */);
            //worker task
        }
    }
