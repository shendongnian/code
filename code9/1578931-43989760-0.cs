	Task<T> GetCachedDataAsync(string key)
	{
		if(cache.TryGetvalue(key, out T value))
		{
			return Task.FromResult(value); // synchronous: no awaits here.
		}
		
        // start a fully async op.
		return GetDataImpl();
		
		async Task<T> GetDataImpl()
		{
			T value = await database.GetValueAsync(key);
			cache[key] = value;
			return value;
		}
	}
