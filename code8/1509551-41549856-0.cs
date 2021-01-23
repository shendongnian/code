	private static readonly char GraphBackgroundChar = '0';
	private static readonly char GraphBarChar = '1';
	
	void Main()
	{
		int[] input = {4, 1, 6, 2};
		int graphHeight = input.Max();
		
		for (int i = 0; i < graphHeight; i++)
		{
			int currentLevel = graphHeight - i - 1;
			OutputLayer(input, currentLevel);
		}
		
	}
	
	private static void OutputLayer(int[] input, int currentLevel)
	{
		foreach (int value in input)
		{
			char c = currentLevel >= value
				? GraphBackgroundChar
				: GraphBarChar;
			Console.Write(c);
		}
		Console.WriteLine();
	}
