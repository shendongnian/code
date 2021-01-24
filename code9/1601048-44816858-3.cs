	public static class LinqExtensions
	{
		public static IEnumerable<Tuple<T, T>> GroupBy2<T>(this IEnumerable<T> source)
		{
			var enumerator = source.GetEnumerator();
			try
			{
				while (true)
				{
					T first, second;
				
					if (!enumerator.MoveNext())
						yield break;
						
					first = enumerator.Current;
					
					if (!enumerator.MoveNext()) {
						yield return new Tuple<T, T>(first, default(T));
						yield break;
					}
					
					second = enumerator.Current;
					
					yield return new Tuple<T, T>(first, second);
				}
			}
			finally
			{
				if (enumerator != null)
					enumerator.Dispose();
			}
		}
	}
