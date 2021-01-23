	public static IDictionary<TKey, TValue> AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
	{
		// Initialize the Dictionary if null
		if (dictionary == null)
			dictionary = new Dictionary<TKey, TValue>();
		// Update value if key already exists
		if (dictionary.ContainsKey(key))
			dictionary[key] = value;
		else
			// Insert value with the given key
			dictionary.Add(key, value);
		
		return dictionary;
	}
