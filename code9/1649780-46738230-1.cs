    public static bool IsGuidInList(List<string> guids, string guidToFind)
    {
    	try
    	{
    		var guid = new Guid(guidToFind.Trim());
    			return
    				guids
    				.Select(x =>
    				{
    					try
    					{
    						new Guid(x.Trim())
    
    					}
    					catch
    					{
    						return null;
    					}
    				})
    				.Where(x => x.HasValu)
    				.Any(x => x.Value == guid);
    	}
    	catch { } // swallow exception
    	return false;
    }
