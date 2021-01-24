	public static int WithDictionary(int[] input)
	{
		var counts = new Dictionary<int, int>();
		
		foreach (int n in input)
		{
			if (!counts.ContainsKey(n))
			{
				counts[n]=1;
			}
			else
			{
				counts[n]++;
			}
		}
		foreach (var d in counts)
		{
			if (d.Value % 2 == 1) return d.Key;
		}
		return -1;
	}
