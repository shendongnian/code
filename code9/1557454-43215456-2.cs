    public static class Iterators
    {
    	public static IEnumerable<T> Lazy<T>(Func<IEnumerable<T>> factory)
    	{
    		return LazyIterator(new Lazy<IEnumerable<T>>(factory));
    	}
    
    	private static IEnumerable<T> LazyIterator<T>(Lazy<IEnumerable<T>> source)
    	{
    		foreach (var item in source.Value)
    			yield return item;
    	}
    }
 
