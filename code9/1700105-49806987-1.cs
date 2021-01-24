    public void RemoveViewFromCache(string viewName, string controller, bool isLayout, bool isPartial = false, string pageName = null, string areaName = null) {
            
         var key = new ViewLocationCacheKey(viewName, controller, areaName, pageName, !isLayout | !isPartial, isLayout ? null : new Dictionary<string, string>(StringComparer.Ordinal))
        
         base.ViewLookupCache.Remove(key);
    }
