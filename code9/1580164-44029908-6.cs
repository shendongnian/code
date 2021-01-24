    for (int i = 0; i < threadCounter; i++)
    {
        ThreadPool.QueueUserWorkItem(RunScanTcp);
    }
    
    private void RunScanTcp(object stateInfo) 
    {
        // Do CPU bound operation here.
        var a = 100;
        while (--a != 0)
        {
            // mre is used to block and release threads manually. It is
            // created in the unsignaled state.
            ManualResetEventSlim mre = new ManualResetEventSlim(false);
    
            Activity.RunOnUiThread(() =>
            {
                // Update UI here.
                // Release Manual reset event.
                mre.Set();
            });
    
            // Wait until UI operation ends.
            mre.WaitOne();
        }
    }
