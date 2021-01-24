	public static IEnumerable<IEnumerable<TSource>> Batches<TSource>(this IEnumerable<TSource> source, int size)
	{
		if (source == null) throw new ArgumentNullException(nameof(source));
		if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size), size, "Value must be greater than zero!");
		return BatchIterator(source, size);
    }
	private static IEnumerable<IEnumerable<TSource>> BatchIterator<TSource>(IEnumerable<TSource> source, int size)
	{
		using (IEnumerator<TSource> enumerator = source.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				TSource[] array = new TSource[size];
				array[0] = enumerator.Current;
				for (int current = 1; current < size; current++)
				{
					if (!enumerator.MoveNext())
					{
						yield return array.Take(current);
						yield break;
					}
					array[current] = enumerator.Current;
				}
				yield return array.Select(s => s);
			}
		}
	}
