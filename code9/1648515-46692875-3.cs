    Dictionary<string, List<string>> resultKeys = new Dictionary<string, List<string>>();
    
    using (StreamReader reader = File.OpenText("test.reg"))
    {
    	List<string> keyAndValues = new List<string>();
    	while (!reader.EndOfStream)
    	{
    		string line = reader.ReadLine();
    
    		// Adds key and values to a list until it finds a blank line
    		if (!string.IsNullOrWhiteSpace(line))
    			keyAndValues.Add(line);
    		else
    		{
    			// Adds a new entry to the dictionary using the first value as key and the rest of the list as value
    			if (keyAndValues != null && keyAndValues.Count > 0)
    				resultKeys.Add(keyAndValues[0], keyAndValues.Skip(1).ToList());
    
    			// Starts a new Key collection
    			keyAndValues = new List<string>();
    		}
    	}
    }
