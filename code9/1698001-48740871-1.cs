    public static class Cache
    {
        public static object Get(string key)
        {
            return MemoryCache.Default[key];
        }
        public static void Set(string key, object data, int duration = 30)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(duration);
            MemoryCache.Default.Add(new CacheItem(key, data), policy);
        }
        public static void Invalidate(string key)
        {
            MemoryCache.Default.Remove(key);
        }
    }
        
        
    
