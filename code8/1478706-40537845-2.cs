    public static class Iterators
    {
    	public static IEnumerable<T> Lazy<T>(Func<IEnumerable<T>> source)
    	{
    		foreach (var item in source())
    			yield return item;
    	}
    }
