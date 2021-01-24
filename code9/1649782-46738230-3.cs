    public static bool IsGuidInList(List<string> guids, string guidToFind)
    {
    	try
    	{
    		var guid = new Guid(guidToFind.Trim());
    		return
    			guids
    			.Select(x =>
    			{
    			    Guid result;
				    return Guid.TryParse(x, out result) ? (Guid?)result : null;
    			})
    			.Where(x => x.HasValue)
    			.Any(x => x.Value == guid);
    	}
    	catch { } // swallow exception
    	return false;
    }
