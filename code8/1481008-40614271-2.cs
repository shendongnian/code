    public static class RxExtensions
    {
    	public static IObservable<T> Cache<T, TKey>(this IObservable<T> newElements, IEnumerable<T> seedElements, Func<T, TKey> replacementSelector)
    	{
    		return seedElements.ToObservable()
    			.Concat(newElements)
    			.GroupBy(i => replacementSelector)
    			.SelectMany(grp => grp.Replay(1).Publish().RefCoun‌​t());
    	}
    }
