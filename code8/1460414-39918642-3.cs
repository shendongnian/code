    private string GetNewToken()
    {
	    lock (cacheLock)
	    {
            // no token in cache so go get a new one
            var newToken = TokenServiceAgent.GetJwt();
            // number of minutes (offset) before JWT expires that will trigger update of cache 
            var cacheLifetime = 15
            CacheItemPolicy cip = new CacheItemPolicy()
            {
                AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(cacheLifetime.Value))
            };
            MemoryCache.Default.Set("tokenkey", newToken, cip);
            return newToken;
        }
    }
