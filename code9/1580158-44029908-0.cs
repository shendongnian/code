    for (int i = 0; i < threadCounter; i++)
    {
        ThreadPool.QueueUserWorkItem(RunScanTcp);
    }
    
    private void RunScanTcp(object stateInfo) 
    {
        // Do CPU bound operation here.
        
        // mre is used to block and release threads manually. It is
        // created in the unsignaled state.
        ManualResetEvent mre = new ManualResetEvent(false);
    
        Activity.RunOnUiThread(() =>
        {
            // Update UI here.
            // Release Manual reset event.
            mre.Set();
        });
    
        // Wait until UI operation ends.
        mre.WaitOne();
    }
