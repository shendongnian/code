	public static IEnumerable<string> Find(List<string> list, string firstFewLetters, int maxHits)
	{
		var index = list.BinarySearch(firstFewLetters);
		if (index < 0)
		{
			index = ~index;
		}
		for (int i=index; i<Math.Min(list.Count, index+maxHits-1); i++)
		{
			var s = list[index + i];
			if (!s.StartsWith(firstFewLetters)) break;
			yield return s;
		}
	}
