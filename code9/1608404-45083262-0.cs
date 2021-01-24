    public object GetCacheItem(string key, Func<object> getObject, TimeSpan duration)
    {
        var value = GetItemFromCache(key);
        if (value == null)
        {
            value = getObject();
            _cache.Insert(
                key,
                value,
                null,
                System.Web.Caching.Cache.NoAbsoluteExpiration,
                duration,
                System.Web.Caching.CacheItemPriority.Normal,
                null);
        }
            
        return value;
    }
