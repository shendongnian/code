    public sealed class MemoryCacheCacheAdapter : ICache
    {
        private static readonly ObjectCache Cache = MemoryCache.Default;
        public T GetOrAdd<T>(string key, TimeSpan cacheDuration, Func<T> valueFactory)
        {
            object value = Cache[key];
            if (value == null)
            {
                value = valueFactory();
                Cache.Add(key, value, new CacheItemPolicy 
                {
                    AbsoluteExpiration = DateTimeOffset.UtcNow + cacheDuration
                });
            }
            return (T)value;
        }
    }
