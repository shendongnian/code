        private static readonly ConcurrentDictionary<object, SemaphoreSlim> _keyLocks = new ConcurrentDictionary<object, SemaphoreSlim>();
        private static readonly ConcurrentDictionary<object, Tuple<string, DateTime>> _cache = new ConcurrentDictionary<object, Tuple<string, DateTime>>();
        private static bool IsExpiredDelete(Tuple<string, DateTime> value, string key)
        {
            bool _is_exp = (DateTime.Now - value.Item2).TotalMinutes > Expiration;
            if (_is_exp)
            {
                _cache.TryRemove(key, out value);
            }
            return _is_exp;
        }
        public async Task<string> GetSomethingAsync(string key)
        {
            Tuple<string, DateTime> cached;
            // get the semaphore specific to this key
            var keyLock = _keyLocks.GetOrAdd(key, x => new SemaphoreSlim(1));
            await keyLock.WaitAsync();
            try
            {
                // try to get value from cache
                if (!_cache.TryGetValue(key, out cached) || !IsExpiredDelete(cached,key))
                {
                    keyLock.Release();
                    string value = await GetSomethingTheLongWayAsync();
                    DateTime creation = DateTime.Now; 
                    // get the semaphore specific to this key
                    keyLock = _keyLocks.GetOrAdd(key, x => new SemaphoreSlim(1));
                    await keyLock.WaitAsync();
                    bool notFound;
                    if (notFound = !_cache.TryGetValue(key, out cached) || IsExpiredDelete(cached, key))
                    {
                        cached = new Tuple<string, DateTime>(value, creation);
                        _cache.TryAdd(key, cached);
                    }
                    else
                    {
                        if (!notFound && cached.Item2 < creation)
                        {
                            cached = new Tuple<string, DateTime>(value, creation);
                        _cache.TryAdd(key, cached);
                        }
                    }
                }
            }
            finally
            {
                keyLock.Release();
            }
            return cached?.Item1;
        }
