    private static readonly ConcurrentDictionary<string, CountedLock> _locks 
        = new ConcurrentDictionary<string, CountedLock>();
    public static void DoSomethingMutuallyExclusiveByName(string resourceName)
    {
        CountedLock resourceLock;
        // we must use a loop to avoid incrementing a stale lock object
        var spinWait = new SpinWait();
        while (true)
        {
            resourceLock = _locks.GetOrAdd(resourceName, i => new CountedLock());
            resourceLock.Increment();
            // check that the instance wasn't removed in the meantime
            if (resourceLock == _locks.GetOrAdd(resourceName, i => new CountedLock()))
                break;
            // otherwise retry
            resourceLock.Decrement();
            spinWait.SpinOnce();
        }
        try
        {
            lock (resourceLock)
            {
                // EnterCriticalSection(resourceName);
            }
        }
        finally
        {
            if (resourceLock.Decrement() <= 0)
                _locks.TryRemove(resourceName, out resourceLock);
        }
    }
