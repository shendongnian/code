    public static class EnumerableExtensions
    {
    	public static void ForFirst<T>(this IEnumerable<T> arr, Func<T, bool> predicate, Action<T> action)
    	{
    		using (var enumerator = arr.GetEnumerator())
    		{
    			while (enumerator.MoveNext())
    			{
    				if (predicate(enumerator.Current))
    				{
    					action(enumerator.Current);
    					return;
    				}
    			}
    		}
    	}
    }
