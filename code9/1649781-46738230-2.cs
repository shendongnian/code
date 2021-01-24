    public static bool IsGuidInList(List<string> guids, string guidToFind)
    {
    	try
    	{
    		var guid = new Guid(guidToFind.Trim());
    		return
    			guids
    			.Select(x =>
    			{
    				Guid? result = null;
    				try
    				{
    					result = new Guid(x);
    
    				}
    				catch { }
    				return result;
    			})
    			.Where(x => x.HasValue)
    			.Any(x => x.Value == guid);
    	}
    	catch { } // swallow exception
    	return false;
    }
