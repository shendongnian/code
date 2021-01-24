	public static bool Check2DArray(int[,] data, int[,] find)
	{
		for (int dRow = 0; dRow < data.GetLength(0) - find.GetLength(0); dRow++)
		{
			for (int dCol = 0; dCol < data.GetLength(1) - find.GetLength(1); dCol++)
			{
				bool found = true;
				for (int fRow = 0; fRow < data.GetLength(0); fRow++)
				{
					for (int fCol = 0; fRow < data.GetLength(1); fRow++)
					{
						if (data[dRow + fRow, dCol + fCol] != find[fRow,fCol])
						{
							found = false;
							break;
						}
					}
					if (!found) break;
				}
				if (found) return true;
			}
		}
		return false;
	}
