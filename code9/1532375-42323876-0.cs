	public static T OneOnlyThenFirstOrDefault<T>(this IEnumerable<T> source)
	{
		var beginning = source.Take(2).ToArray();
	    return beginning.Length == 1 ? beginning[0] : default(T);
	}
