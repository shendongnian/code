	public static IEnumerable<IEnumerable<T>> GetOrderedPermutations<T>( IList<T> source, int k )
	{
		if( k == 0 ) yield return Enumerable.Empty<T>();
		if( k == source.Count ) yield return source;
	    if( k > source.Count ) yield break;
	 	var pointers = Enumerable.Range( 0, k ).ToArray();
				
        // The first element of our permutation can only be in the first
        // Count - k + 1 elements.  If it moves past here, we can't have
        // anymore permutations because there aren't enough items in the list.
		while( pointers[0] <= source.Count - k )
		{
			yield return pointers.Select( p => source[p] );
            // Increment the last pointer
			pointers[k - 1]++;
			
            // The i variable will keep track of which pointer
            // we need to increment.  Start it at the second to
            // last (since this is the one that we're going to
            // increment if the last pointer is past the end).
			int i = k - 2;
			while( pointers[k - 1] >= source.Count && i >= 0 )
			{
                // Okay, the last pointer was past the end, increment
				pointers[i]++;
                // Reset all the pointers after pointer i
				for( int j = i + 1; j < k; ++j )
				{
					pointers[j] = pointers[j - 1] + 1;
				}
                // If the last pointer is still past the end, we'll
                // catch it on the next go-around of this loop.
                // Decrement i so we move the previous pointer next time.
				
				--i;
			}
		}
	}
