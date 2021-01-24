    static Semaphore _semaphore;
    void DoWork()
    {
        _semaphore.WaitOne();
        try
        {
            Foo();  //Only one thread will be able to execute this at a time
        }
        finally
        {
            _semaphore.Release();
        }
    }
    void HandleProgressChanged()
    {
        _semaphore.WaitOne(); //Wait for any DoWork threads to finish
        try
        {
            Bar();
        }
        finally
        {
            _semaphore.Release();
        }
        Task.Run(DoWork);
    }
