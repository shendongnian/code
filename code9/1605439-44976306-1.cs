	public static IEnumerable<int> GetSequenceWithSum( Random rand, int count, int sum )
	{
        // Get a list of count-1 random numbers in the range [0, sum] in ascending order.
        // This partitions the range [0, sum] into count different bins of random size.
		var partition = Enumerable.Range( 0, count - 1 )
								  .Select( _ => rand.Next( 0, sum + 1 ) )
								  .OrderBy( x => x );
					
        // Yield the size of each partition in the range.
		int previous = 0;
		foreach( int value in partition )
		{
			yield return value - previous;
			previous = value;
		}
		
		yield return sum - previous;
	}
