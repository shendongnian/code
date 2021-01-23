	public int[,] BuildMap(int w, int h, int[] xList, int[] yList)
	{
		if (xList.Length == 0)
			throw new ArgumentException("at least one coordinate pair must be supplied");
		if (xList.Length != yList.Length)
			throw new ArgumentException("coordinate lists must have equal length");
		int[,] map = new int[w, h];
		// Iterate over each map tile
		for (int x = 0; x < w; x++)
		{
			for (int y = 0; y < h; y++)
			{
				// Set storage variable
				int temp = int.MaxValue;
				// Iterate over each point in x/y lists
				for (int idx = 0; idx < xList.Length; idx++)
				{
					// Find the nearest point
					// Distance = |x - px| + |y - py|
					temp = Math.Min(Math.Abs(x - xList[idx]) + Math.Abs(y - yList[idx]), temp);
				}
				// Assign the shortest distance
				map[x, y] = temp;
			}
		}
		return map;
	}
