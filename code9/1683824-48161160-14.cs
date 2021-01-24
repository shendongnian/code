	public static int WithDictionaryAndLinq(int[] input)
	{
		var counts = input.GroupBy( n => n )
                          .ToDictionary( g => g.Key, g=> g.Count() );
		foreach (var d in counts)
		{
			if (d.Value % 2 == 1) return d.Key;
		}
		return -1;
	}
