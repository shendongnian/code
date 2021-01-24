    public void CacheItemRemovedCallback(string key, object value, CacheItemRemovedReason reason)
    {
         //Your code here, call database procedures ...
         HttpRuntime.Cache.Add("cacheKey", "cacheValue", null, DateTime.MaxValue, TimeSpan.FromSeconds(600), CacheItemPriority.NotRemovable, new CacheItemRemovedCallback(CacheItemRemovedCallback));
    }
