    private static readonly object GetMyObjLock = new object();
    public static MyObject GetFromCache()
    {
        var key = "MyObj";
        var cache = HttpContext.Current.Cache;
        MyObject result = null;
        while(result == null)
        {
            //Try to pull from the cache.
            result = (MyObject)cache[key];
            if(result == null)
            {
                //Try to add to cache, if the object was already added this
                // function returns the previously added instance.
                result = (MyObject)cache.Add(key,
                    new MyObject(), null,
                    Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration,
                    CacheItemPriority.Normal, null);
            }   
        }
        return result;
    }
