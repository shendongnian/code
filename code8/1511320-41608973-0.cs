    public static class EnumerableExtensions
    {
    	public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> selector)
    	{
    		foreach (var parent in source)
    		{
    			yield return parent;
    		
    			var children = selector(parent);
    			foreach (var child in SelectRecursive(children, selector))
    				yield return child;
    		}
    	}
    }
