    public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(this IEnumerable<TSource> items, int size)
	{
		return items.Batch(size, x => x);
	}
	public static IEnumerable<TResult> Batch<TSource, TResult>(this IEnumerable<TSource> items, int size, 
		Func<IEnumerable<TSource>, TResult> selector)
	{
		if (items == null)
			throw new ArgumentException(nameof(items));
		if (size <= 0)
			throw new ArgumentOutOfRangeException(nameof(size));
		if (selector == null)
			throw new ArgumentNullException(nameof(selector));
		using (var enumerator = items.GetEnumerator())
		{
			var taken = 0;
			while (enumerator.MoveNext())
			{
				yield return selector(items.Skip(taken)
					.Take(size));
				for (int i = 0; i < size - 1; i++)
					if (!enumerator.MoveNext())
						break;
				taken += size;
			}
		}
	}
