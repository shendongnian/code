    using System.Runtime.Caching;
    private static object _lock = new object();
    private void AddToDataFlow(string file)
    {
        lock (_lock)
        {
            if (MemoryCache.Default.Contains(file))
            {
                return;
            }
            // no matter what to put into the cache
            MemoryCache.Default[file] = true;
        // we can now exit the lock
        }
        workerBlock.Post(file);
    }
