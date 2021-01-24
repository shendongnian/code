    public static class EnumerableExtennisons
    {
    	public static IEnumerable<T> AsDisposable<T>(this IEnumerable<T> source)
    		where T : IDisposable
    	{
    		foreach (var item in source)
    		{
    			using (item)
    				yield return item;
    		}
    	}
    }
