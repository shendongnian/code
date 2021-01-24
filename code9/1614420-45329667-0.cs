    ///Your Extensions class
	public static class MyExtensions
	{
		public static IEnumerable<T> Filter<T> ( this IEnumerable<T> src, params Func<T, bool>[] predicates )
		{
			IEnumerator<T> enumerator = src.GetEnumerator();
			while ( enumerator.MoveNext() )
				if ( predicates.All( condition => condition( enumerator.Current ) ) )
					yield return enumerator.Current;
		}
