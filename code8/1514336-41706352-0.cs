    public static Dictionary<string, Dictionary<string, string>> URLs
	{
		get
		{
			if (_URLs != null)
				return _URLs;
			_URLs =
				typeof(HealthURLs).GetNestedTypes(BindingFlags.Static | BindingFlags.Public)
				.Select(m => new KeyValuePair<string, Dictionary<string, string>>(
						m.Name, 
						m.GetFields()
							.Select(k => new KeyValuePair<string, string>(
								k.Name, 
								k.GetValue(null).ToString()))
							.ToDictionary(x => x.Key, x => x.Value)))
				.ToDictionary(x => x.Key, x => x.Value);
			return _URLs;
		}
	}
