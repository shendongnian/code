	public static class Ex
	{
		public static IEnumerable<R> Select<T, R>(this IEnumerable<T> source, Func<T, int, R> projection)
		{
			int index = 0;
			foreach (var item in source)
			{
				yield return projection(item, index++);
			}
		}
	}
