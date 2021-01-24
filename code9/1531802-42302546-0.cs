    ObjectCache cache = System.Runtime.Caching.MemoryCache.Default;
    CacheItemPolicy policy = new CacheItemPolicy
    {
        Priority = CacheItemPriority.NotRemovable,
        AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10);
    };
    cache.Add(item, policy);
