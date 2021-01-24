	public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int size)
	{
		var mover = source.GetEnumerator();
		var currentSet = new List<T>();
		while (mover.MoveNext())
		{
			currentSet.Add(mover.Current);
			if (currentSet.Count >= size)
			{	
				yield return currentSet;
				currentSet = new List<T>();
			}
		}
		if (currentSet.Count > 0)
			yield return currentSet;
	}
