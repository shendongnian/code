    public static class IObservableIEnumerableExtensions
    {
    	public static IObservable<IEnumerable<T>> GetAddedElements<T>(this IObservable<IEnumerable<T>> source)
    	{
    		return source.Zip(source.StartWith(Enumerable.Empty<T>()), (newer, older) => newer.Except(older));
    	}
    
    	public static IObservable<IEnumerable<T>> GetRemovedElements<T>(this IObservable<IEnumerable<T>> source)
    	{
    		return source.Zip(source.StartWith(Enumerable.Empty<T>()), (newer, older) => older.Except(newer));
    	}
    }
