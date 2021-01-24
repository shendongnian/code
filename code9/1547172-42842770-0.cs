    public static IEnumerable<T> Yield<T>( T value )
	{
	    yield return value;
	}
    public static IEnumerable<IEnumerable<T>> GetOrderedPermutations<T>( IEnumerable<T> source, int k )
    {
		if( k == 0 ) return new[] { Enumerable.Empty<T>() };
		
		int length = source.Count();
		
		if( k == length ) return new[] { source };
		
		if( k > length ) return Enumerable.Empty<IEnumerable<T>>();
		
		return GetOrderedHelper<T>( source, k, length );
    }
	
	private static IEnumerable<IEnumerable<T>> GetOrderedHelper<T>( IEnumerable<T> source, int k, int length )
	{
		if( k == 0 )
		{
			yield return Enumerable.Empty<T>();
			yield break;
		}
		int i = 0;
		foreach( var item in source )
		{
			if( i + k > length ) yield break;
			var permutations = GetOrderedHelper<T>( source.Skip( i + 1 ), k - 1, length - i );
			i++;
			
			foreach( var subPerm in permutations )
			{
				yield return Yield( item ).Concat( subPerm );
			}
		}
	}
