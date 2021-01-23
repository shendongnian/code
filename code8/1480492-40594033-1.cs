    var myObj = GetFromCache();
    public static MyObject GetFromCache()
    {
        var key = "MyObj";
        var cache = HttpContext.Current.Cache;
        if (cache[key] == null)
        {
            lock (GetMyObjLock)
            {
                if (cache[key] == null)
                {
                    cache.Add(key,
                        new MyObject(), null,
                        Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration,
                        CacheItemPriority.Normal, null);
                }
            }   
        }
