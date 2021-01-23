	public IEnumerable<JToken> GetTokensByPath(TextReader tr, string path)
	{
		// do our best to convert the path to a RegEx
		var regex = new Regex(path.Replace("[*]", @"\[[0-9]*\]"));
	    using (var reader = new JsonTextReader(tr))
	    {
	        while (reader.Read())
	        {
	            if (regex.IsMatch(reader.Path))
	                yield return JToken.Load(reader);
	        }
	    }
	}
