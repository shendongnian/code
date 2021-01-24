    public object Get(FindItems request)
    { 
        return Request.ToOptimizedResultUsingCache(base.Cache,cacheKey,()=> 
        {
            return new FindItemResponse { ... }
        });        
    }
