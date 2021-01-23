	private static readonly char GraphBackgroundChar = '0';
	private static readonly char GraphBarChar = '1';
	
	void Main()
	{
		int[] input = {4, 1, 6, 2};
		int graphHeight = input.Max(); // using System.Linq;
		
		for (int currentHeight = graphHeight - 1; currentHeight >= 0; currentHeight--)
		{
			OutputLayer(input, currentHeight);
		}
	}
	
	private static void OutputLayer(int[] input, int currentLevel)
	{
		foreach (int value in input)
		{
            // We're currently printing the vertical level `currentLevel`.
            // Is this value's bar high enough to be shown on this height?
			char c = currentLevel >= value
				? GraphBackgroundChar
				: GraphBarChar;
			Console.Write(c);
		}
		Console.WriteLine();
	}
