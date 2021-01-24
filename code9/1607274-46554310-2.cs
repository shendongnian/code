      object aspNetCacheInternal = null;
      
      var cacheInternalPropInfo = typeof(HttpRuntime).GetProperty("CacheInternal", BindingFlags.NonPublic | BindingFlags.Static);
      if (cacheInternalPropInfo == null)
      {
        // At some point, after some .NET Framework's security update, that internal member disappeared.
        // https://stackoverflow.com/a/45045160
        // 
        // We need to look for internal cache otherwise.
        //
        var cacheInternalFieldInfo = HttpRuntime.Cache.GetType().GetField("_internalCache", BindingFlags.NonPublic | BindingFlags.Static);
        if (cacheInternalFieldInfo != null)
        {
          var httpRuntimeInternalCache = cacheInternalFieldInfo.GetValue(HttpRuntime.Cache);
          var httpRuntimeInternalCacheField = httpRuntimeInternalCache.GetType().GetField("_cacheInternal", BindingFlags.NonPublic | BindingFlags.Instance);
            
          if (httpRuntimeInternalCacheField != null)
            aspNetCacheInternal = httpRuntimeInternalCacheField.GetValue(httpRuntimeInternalCache);
        }
      }
      else
      {
        aspNetCacheInternal = cacheInternalPropInfo.GetValue(null, null);
      }
      return aspNetCacheInternal;
