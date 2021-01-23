    using System;
    using System.Collections.Generic;
    using System.Runtime.Caching;
    
    public class CacheService 
    {
        protected ObjectCache Cache => MemoryCache.Default;
    
        public T Get<T>(string key)
        {
            return (T) Cache[key];
        }
    
        public void Set(string key, object data, int cacheTime)
        {
            if (data == null)
                return;
    
            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            Cache.Add(new CacheItem(key, data), policy);
        }
    
        public void Remove(string key)
        {
            Cache.Remove(key);
        }
    }
