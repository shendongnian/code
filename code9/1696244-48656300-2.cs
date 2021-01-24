    public string CompanyName { get { return GetCompanyName(); } }
	private string GetCompanyName()
	{
		string result;
		// Look for cache key.
		if (!_cache.TryGetValue(CacheKeys.CompanyName, out result))
		{
			// Key not in cache, so get data.
			result = // Lookup data from db
			// Set cache options.
			var cacheEntryOptions = new MemoryCacheEntryOptions()
				// Keep in cache for this time, reset time if accessed.
				.SetSlidingExpiration(TimeSpan.FromMinutes(60));
			// Save data in cache.
			_cache.Set(CacheKeys.CompanyName, result, cacheEntryOptions);
		}
		return result;
	}
