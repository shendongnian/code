	public static IEnumerable<T> GetDuplicates<T>(this IEnumerable<T> items)
	{
		HashSet<T> seen = new HashSet<T>();
		foreach (var item in items)
			if (seen.Contains(item))
				yield return item;
			else
				seen.Add(item);
	}
	
