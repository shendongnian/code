	public static string RemoveEmptyUrlParameters(string input)
    {
		var results = HttpUtility.ParseQueryString(input);
		
		Dictionary<string, string> nonEmpty = new Dictionary<string, string>();
		foreach(var k in results.AllKeys)
		{
			if(!string.IsNullOrWhiteSpace(results[k]))
			{
				nonEmpty.Add(k, results[k]);
			}
		}
        return string.Join("&", nonEmpty.Select(kvp => $"{kvp.Key}={kvp.Value}"));
    }
