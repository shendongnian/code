    public static class EnumerableExtensions
    {
    	public static IEnumerable<T> SkipLastWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    	{
    		var skipBuffer = new List<T>();
    		foreach (var item in source)
    		{
    			if (predicate(item))
    				skipBuffer.Add(item);
    			else
    			{
    				foreach (var skipped in skipBuffer)
    					yield return skipped;
    				skipBuffer.Clear();
    				yield return item;
    			}
    		}
    	}
    }
