    public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable) where T : IEquatable<T>
	{
		T previous = default(T);
		foreach (var t in iterable)
		{
			if (t.Equals(previous))
				yield return t;
			previous = t;
		}
	}
