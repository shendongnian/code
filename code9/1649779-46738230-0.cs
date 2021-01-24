    public static bool IsGuidInList(List<string> guids, string guidToFind)
    {
    	try
    	{
    		var guid = new Guid(guidToFind.Trim());
    		return 
    		    guids
    		    .Select(x => new Guid(x.Trim()))
    		    .Any(x => x == guid);
    	}
    	catch { } // swallow exception
    	return false;
    }
