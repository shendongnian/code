    public static class Extensions
    {
    	public static IEnumerable<T> RemoveNullsAndConvert<T>(this IEnumerable<T?> source)
    		where T : struct
    	{
    		foreach (var x in source)
    			if (x != null) yield return x.Value;
    	}
    }
 
