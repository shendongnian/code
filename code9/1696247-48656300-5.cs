    public CultureInfo[] Cultures { get { return GetCultures(); } }
	private CultureInfo[] GetCultures()
	{
		string result;
		// Look for cache key.
		if (!_cache.TryGetValue(CacheKeys.Cultures, out result))
		{
			// Key not in cache, so get data.
			result = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
			// Set cache options.
			var cacheEntryOptions = new MemoryCacheEntryOptions()
				// Keep in cache for this time, reset time if accessed.
				.SetSlidingExpiration(TimeSpan.FromMinutes(60));
			// Save data in cache.
			_cache.Set(CacheKeys.Cultures, result, cacheEntryOptions);
		}
		return result;
	}
