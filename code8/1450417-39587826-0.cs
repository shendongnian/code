    void Application_Start ()
      {
          _cache = Context.Cache;  
          _cache.Insert ("mycahce", mystaticvariabledata, null,
          Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration,
          CacheItemPriority.Default,null);
      }
