	void UpdateCounts(ConcurrentDictionary<string, ObjectCount> dict, string key, int toAdd)
	{
		var addOrUpdateValue = ccd.AddOrUpdate(key,
			new ObjectCount(new object(), 1),
			(k, pair) => new ObjectCount(pair.Key, pair.Value + toAdd));
			
		if(addOrUpdateValue.Count == 0)
		{
			(ICollection<KeyValuePair<string, ObjectCount>>).Remove(
                new KeyValuePair<string, ObjectCount>(key, addOrUpdateValue));
		}
	}
