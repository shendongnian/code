	public static IEnumerable<string> Find(List<string> list, string firstFewLetters, int maxHits)
	{
		var startIndex = list.BinarySearch(firstFewLetters);
		
		//If negative, no match. Take the 2's complement to get the index of the closest match.
		if (startIndex < 0)
		{
			startIndex = ~startIndex;  
		}
		
		//Take maxHits items, or go till end of list
		var endIndex = Math.Min( 
			                     startIndex + maxHits - 1, 
                                 list.Count-1 
                               ); 
		
		//Enumerate matching items
		for ( int i = startIndex; i <= endIndex; i++ )
		{
			var s = list[i];
			if (!s.StartsWith(firstFewLetters)) break;  //This line is optional
			yield return s;
		}
	}
