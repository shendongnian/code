	public static IEnumerable<T> GetDistribution<T>( IEnumerable<Tuple<T, int>> itemCounts )
	{
		var groupCounts = itemCounts.GroupBy( pair => pair.Item1 )
									.Select( g => new { Item = g.Key, Count = g.Sum( pair => pair.Item2 ) } )
									.OrderByDescending( g => g.Count )
									.ToList();
									
		int maxCount = groupCounts[0].Count;
		var errorValues = new int[groupCounts.Count];
									  
	    for( int i = 1; i < errorValues.Length; ++i )
		{
			var item = groupCounts[i];
			errorValues[i] = 2 * groupCounts[i].Count - maxCount;
		}
		
		for( int i = 0; i < maxCount; ++i )
		{
			yield return groupCounts[0].Item;
			
			for( int j = 1; j < errorValues.Length; ++j )
			{
				if( errorValues[j] > 0 )
				{
					yield return groupCounts[j].Item;
					errorValues[j] -= 2 * maxCount;
				}
				
				errorValues[j] += 2 * groupCounts[j].Count;
			}
		}
	}
