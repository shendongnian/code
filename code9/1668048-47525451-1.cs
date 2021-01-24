    static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
    static CancellationTokenSource cts = new CancellationTokenSource();
    static void CriticalSection()
    {
        if(!cts.Token.IsCancellationRequested)
        {
            try
            {
                semaphore.Wait(cts.Token);
            }
            catch (OperationCanceledException ) { }
        }
        /*
        Critical section here
        */
        if(!cts.Token.IsCancellationRequested)
            cts.Cancel();
    }
