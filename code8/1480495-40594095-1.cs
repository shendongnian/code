    private static readonly object GetMyObjLock = new object();
    public static MyObject GetFromCache()
    {
        var key = "MyObj";
        var cache = HttpContext.Current.Cache;
        MyObject result = null;
        //Try to pull from the cache.
        result = (MyObject)cache[key];
        if(result == null)
        {
            lock(GetMyObjLock)
            {
                //Check to see if anyone made a new object while we where waiting.
                result = (MyObject)cache[key];
                if(result == null)
                {
                    var newObject = new MyObject();
            
                    //Try to add to cache, if the object was already added this
                    // function returns the previously added instance.
                    result = (MyObject)cache.Add(key,
                        newObject, null,
                        Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration,
                        CacheItemPriority.Normal, null);
            
                    //If result is null then we successfully added a new item, assign it to result.
                    if(result == null)
                        result = newObject;
                    }
                }
            }
        }
        
        return result;
    }
