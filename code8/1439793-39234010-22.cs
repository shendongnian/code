    public class Cached<FromT, ToT>
    {
        private Func<FromT, Task<ToT>> GetSomethingTheLongWayAsync;
        public Cached (Func<FromT, Task<ToT>> _GetSomethingTheLongWayAsync, int expiration_min ) {
            GetSomethingTheLongWayAsync = _GetSomethingTheLongWayAsync;
            Expiration = expiration_min;
    }
        int Expiration = 1;
        private ConcurrentDictionary<FromT, SemaphoreSlim> _keyLocks = new ConcurrentDictionary<FromT, SemaphoreSlim>();
        private ConcurrentDictionary<FromT, Tuple<ToT, DateTime>> _cache = new ConcurrentDictionary<FromT, Tuple<ToT, DateTime>>();
        private bool IsExpiredDelete(Tuple<ToT, DateTime> value, FromT key)
        {
            bool _is_exp = (DateTime.Now - value.Item2).TotalMinutes > Expiration;
            if (_is_exp)
            {
                _cache.TryRemove(key, out value);
            }
            return _is_exp;
        }
        public async Task<ToT> GetSomethingAsync(FromT key)
        {
            Tuple<ToT, DateTime> cached;
            // get the semaphore specific to this key
            var keyLock = _keyLocks.GetOrAdd(key, x => new SemaphoreSlim(1));
            await keyLock.WaitAsync();
            try
            {
                // try to get value from cache
                if (!_cache.TryGetValue(key, out cached) || IsExpiredDelete(cached, key))
                {
                    //possible performance optimization: measure it before uncommenting
                    //keyLock.Release();
                    ToT value = await GetSomethingTheLongWayAsync(key);
                    DateTime creation = DateTime.Now;
                    // in case of performance optimization
                    // get the semaphore specific to this key
                    //keyLock = _keyLocks.GetOrAdd(key, x => new SemaphoreSlim(1));
                    //await keyLock.WaitAsync();
                    bool notFound;
                    if (notFound = !_cache.TryGetValue(key, out cached) || IsExpiredDelete(cached, key))
                    {
                        cached = new Tuple<ToT, DateTime>(value, creation);
                        _cache.TryAdd(key, cached);
                    }
                    else
                    {
                        if (!notFound && cached.Item2 < creation)
                        {
                            cached = new Tuple<ToT, DateTime>(value, creation);
                            _cache.TryAdd(key, cached);
                        }
                    }
                }
            }
            finally
            {
                keyLock.Release();
            }
            return cached.Item1;
        }
        
    }
