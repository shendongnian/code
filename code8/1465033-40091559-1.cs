	public static async Task<TValue> GetOrAddAsync<TKey, TValue>(
		this ConcurrentDictionary<TKey, TValue> dictionary,
        TKey key, Func<TKey, Task<TValue>> valueFactory)
	{
		TValue resultingValue;
	    if (dictionary.TryGetValue(key, out resultingValue))
	    {
	        return resultingValue;
	    }
	    return dictionary.GetOrAdd(key, await valueFactory(key));
	}
