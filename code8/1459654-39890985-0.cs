    public static class CacheSingleton<TK, TV>
    {
        public static ICache<TK, TV> Instance(string cacheName)
        {
            return _cache.GetOrAdd(cacheName, create);
        }
        static ICache<TK, TV> create(string cacheName)
        {
            // Code to create an ICache<TK, TV> given cacheName.
            return null; // Stubbed.
        }
        static readonly ConcurrentDictionary<string, ICache<TK, TV>> _cache = new ConcurrentDictionary<string, ICache<TK, TV>>();
    }
