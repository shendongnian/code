    private long blockedCount = 0;
    private void FastLoop()
    {
        lock (locker)
        {
            while (true)
            {
                DoWork();
                
                while (Interlocked.Read(ref blockedCount) > 0)
                    Monitor.Wait(locker);
            }
        }
    }
    private void OtherThreads()
    {
        try
        {
            var wasBlocked = false;
            if (!Monitor.TryEnter(locker))
            {
                wasBlocked = true;
                Interlocked.Increment(ref blockedCount);
                Monitor.Enter(locker);
            }
            DoSomethingElse();
            if (wasBlocked)
                Interlocked.Decrement(ref blockedCount);
            Monitor.Pulse(locker);
        }
        finally
        {
            Monitor.Exit(locker);
        }
    }
