    var registryLines = File.ReadLines("test.reg");
    
    Dictionary<string, List<string>> resultKeys = new Dictionary<string, List<string>>();
    
    while (registryLines.Count() > 0)
    {
    	// Take the key and values into a single list
    	var keyValues = registryLines.TakeWhile(x => !String.IsNullOrWhiteSpace(x)).ToList();
    
    	// Adds a new entry to the dictionary using the first value as key and the rest of the list as value
    	if (keyValues != null && keyValues.Count > 0)
    		resultKeys.Add(keyValues[0], keyValues.Skip(1).ToList());
    
    	// Jumps to the next registry (+1 to skip the blank line)
    	registryLines = registryLines.Skip(keyValues.Count + 1);
    }
