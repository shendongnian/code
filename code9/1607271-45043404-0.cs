	public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> src, Func<T, TKey> keyFun) {
		var seenKeys = new HashSet<TKey>();
		foreach (T e in src)
			if (seenKeys.Add(keyFun(e)))
				yield return e;
	}
