	public static IEnumerable<string> Find(List<string> list, string firstFewLetters, int maxHits)
	{
		var index = list.BinarySearch(firstFewLetters);
		if (index < 0)
		{
			index = ~index;  //If negative, no match. Take the 2's complement to get the index of the closest match.
		}
		var endIndex = Math.Min(list.Count-1, index + maxHits - 1);  //Get maxHits items, or until end of list
		for ( int i = index; i <= endIndex; i++ )
		{
			var s = list[i];
			if (!s.StartsWith(firstFewLetters)) break;
			yield return s;
		}
	}
