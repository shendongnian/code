    private static IEnumerable<IEnumerable<string>> GetGroups(IEnumerable<string> source)
    	{
    		var grouped = new List<string>();
    		foreach(var el in source)
    		{
    			if(!string.IsNullOrWhiteSpace(el))
    				grouped.Add(el);
    			else if(grouped.Any())
    			{
    				yield return grouped;
    				grouped = new List<string>();
    			}
    		}
    		
    		if(grouped.Any())
    			yield return grouped;
    		
    	}
