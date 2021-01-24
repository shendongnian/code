    var manual = new ManualResetEventSlim(true);
    var auto = new AutoResetEvent(true);
    while (true)
    {
        // check for normal work
        manual.Wait();
        try
        {
        }
        catch
        {
            auto.Wait();
            // only one thread here
            // stop all the worker threads
            manual.Reset();
            // handling here
            // start all the workers
            manual.Set();
            // start exception handlers
            auto.Set();
        }
    }
    
