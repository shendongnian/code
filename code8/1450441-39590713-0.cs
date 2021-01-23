    using System.Runtime.Caching;
    
    
    
    public static TResult GetOrSetFileCache<TResult>(string key, Func<string, TResult> value, string path)
    {
    	if (MemoryCache.Default.Contains(key))
    		return (TResult) MemoryCache.Default.Get(key);
    
    	var val = value(key);
    	
    	var policy = new CacheItemPolicy
                {
                    SlidingExpiration = TimeSpan.FromSeconds(600)
                });
    	policy.ChangeMonitors.Add(new HostFileChangeMonitor(new List<string> { path }))
    	
    	MemoryCache.Default.Set(key, value, policy);
    
    	return val;
    }
