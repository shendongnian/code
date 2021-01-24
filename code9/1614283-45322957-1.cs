    private volatile int blockedCount = 0;
    private void FastLoop()
    {
        lock (locker)
        {
            while (true)
            {
                DoWork();
                
                while (blockedCount > 0)
                    Monitor.Wait(locker);
            }
        }
    }
    private void OtherThreads()
    {
        try
        {
            if (!Monitor.TryEnter(locker))
                Interlocked.Increment(ref blockedCount);
            Monitor.Enter(locker);
            DoSomethingElse();
            Interlocked.Decrement(ref blockedCount);
            Monitor.Pulse(locker);
        }
        finally
        {
            Monitor.Exit(locker);
        }
    }
