	public static class EnumerableExtensions
	{
		public static IOrderedEnumerable<T> OrderByAdaptive<T, TKey>(
            this IEnumerable<T> enumr, 
            Func<T, TKey> selector, 
            bool ascending
        )
		{
			return ascending
				? enumr.OrderBy(selector)
				: enumr.OrderByDescending(selector);
		}
	
		public static IOrderedEnumerable<T> OrderByAdaptive<T, TKey>(
            this IEnumerable<T> enumr, 
            Func<T, TKey> selector, 
            IComparer<TKey> comparer, 
            bool ascending
        )
		{
			return ascending
				? enumr.OrderBy(selector, comparer)
				: enumr.OrderByDescending(selector, comparer);
		}
	}
