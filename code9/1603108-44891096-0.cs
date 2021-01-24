	private static List<lat_longPairs> ParseLatLon(string input)
	{
		var numbers = input.Split(new [] { " " }, StringSplitOptions.RemoveEmptyEntries)
			               .Select(i => decimal.Parse(i))
			               .ToArray();
		
		var latLonPairs = new List<lat_longPairs>();
		
		for (int i = 0; i < numbers.Length; i += 2)
		{
			latLonPairs.Add(new lat_longPairs
			{
				latitude = numbers[i],
				longitude = numbers[i + 1],
			});
		}
		
		return latLonPairs;
	}
