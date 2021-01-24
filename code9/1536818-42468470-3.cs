    protected string GetCacheKey(string memberName)
    {
        // NOTE: We must include IsReadOnly in the request cache key 
        // because we may have a different 
        // result when the sitemap is being constructed than when 
        // it is being read by the presentation layer.
        return "__MVCSITEMAPNODE_" + this.SiteMap.CacheKey + "_" + this.Key 
            + "_" + memberName + "_" + this.IsReadOnly.ToString() + "_";
    }
