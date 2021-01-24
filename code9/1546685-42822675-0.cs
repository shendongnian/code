	Dictionary<int, string> dictionary = new Dictionary<int, string>();
	HashSet<string> values = new HashSet<string>();
	...
	public void AddToDictionary(int key, string value)
	{
		if (values.Contains(value))
			return;
		
		dictionary.Add(key, value);
		values.Add(value);
	}
