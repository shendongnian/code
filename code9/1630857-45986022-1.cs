    static Semaphore _semaphore = new Semaphore();
    WorkStatus _workStatus;
    void DoWork()
    {
        _semaphore.WaitOne();
        try
        {
            _workStatus = Foo();  //Only one thread will be able to execute this at a time
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
            DisplayProgress(_workStatus);
        }
        finally
        {
            _semaphore.Release();
        }
        Task.Run(DoWork);
    }
