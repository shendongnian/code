    public Dictionary<string, object> ToDictionary()
	{
		var dict = new Dictionary<string, object>();
		foreach (var prop in GetType().GetProperties())
		{
			dict.Add(prop.Name, prop.GetValue(this));
		}
		
		return dict;
	}
