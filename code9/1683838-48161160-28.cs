	public static int BruteForce(int[] input)
	{
		for (int i=0; i<=input.GetUpperBound(0); i++)
		{
			int matchCount = 0;
			for (int j=0; j<=input.GetUpperBound(0); j++)
			{
				if (i == j) continue;
				if (input[i] == input[j])
				{
					matchCount++;
				}
			}
			if (matchCount % 2 == 0) return input[i];
		}
		return -1;
	}
