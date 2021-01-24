	private void button1_Click(object sender, EventArgs e)
	{
		Console.WriteLine(Level(0).ToString());
		Console.WriteLine(Level(83).ToString());
		Console.WriteLine(Level(4787746).ToString());
		Console.WriteLine(Level(188884739).ToString());
		Console.WriteLine(Level(188884740).ToString());
		Console.WriteLine(Level(999999999).ToString());
	}
	private List<int> MinimumExperience = null;
	private int Level(int experience)
	{
		if (MinimumExperience == null)
		{
			MinimumExperience = new List<int>();
			List<int> numerators = Enumerable.Range(1, 125).Select(x => (int)Math.Floor((double)x + 300D * Math.Pow(2, (double)x / 7D))).ToList();
			for (int L = 1; L <= 126; L++)
			{
				int sum = 0;
				for (int x = 1; x < L; x++)
				{
					sum = sum + numerators[x - 1];
				}
				MinimumExperience.Add((int)Math.Floor((double)sum / 4D));
			}
		}
		for(int i = 0; i < MinimumExperience.Count; i++)
		{
			if (experience < MinimumExperience[i])
			{
				return i;
			}
		}
		return MinimumExperience.Count;
	}
