	public static double AskForNums()
	{
		return AskForNums(1, 0.0);
	}
	
	private static double AskForNums(int i, double max)
	{
		if (i <= 12)
		{
			Console.WriteLine("Input value for number " + i);
			double input = double.Parse(Console.ReadLine());
	
			if (input > max)
			{
				max = input;
			}
	
			max = AskForNums(i + 1, max);
		}
		return max;
	}
