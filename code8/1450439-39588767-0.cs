    public static class Extensions
    {
    	public static IEnumerable<T> RemoveNullsAndConvert<T>(this IEnumerable<T?> source)
    		where T : struct
    	{
    		return from x in source where x != null select x.Value;
    	}
    }
