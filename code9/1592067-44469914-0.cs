    public static class Ext
    {
    	public static List<string> AddRangeAndReturn(this List<string> list, IEnumerable<string> itemsToAdd)
    	{
    	    list.AddRange(itemsToAdd);
    		
    		return list;
    	}
    }
