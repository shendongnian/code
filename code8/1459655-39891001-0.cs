    public static class CacheSingleton<TK, TV>
    {
    	private static readonly ConcurrentDictionary<string, ICache<TK, TV>> lazyIgnite = new ConcurrentDictionary<string, ICache<TK, TV>>();
    
    	public static ICache<TK, TV> GetInstance(string cacheName)
    	{
    		return lazyIgnite.GetOrAdd(cacheName, name =>
    		{
    			NearCacheConfiguration nearCacheConfig = new NearCacheConfiguration { NearStartSize = 10240000 };
    			var nearCache = IgniteInstance.GetOrCreateNearCache<TK, TV>(name, nearCacheConfig);
    			return nearCache;
    		});
    	}
    }
