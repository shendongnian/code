    public void StoreInDictionary(string[] file, Dictionary<string, string> dictionary)
    {
    	foreach (var line in file)
    	{
    		if (!string.IsNullOrWhiteSpace(line))
    		{
    			string valueOne, valueTwo;
          		var idx = line.IndexOf(',');
    			if (idx >= 0)
    			{
    				valueOne = line.Substring(0, idx);
    				valueTwo = line.Substring(idx + 1);
    			}
    			else
    			{
    				valueOne = line;
    				valueTwo = string.Empty;
    			}
    
    			if (!dictionary.ContainsKey(valueOne))
    			{
    				dictionary.Add(valueOne, valueTwo);
    			}
    		}
    	}
    }
