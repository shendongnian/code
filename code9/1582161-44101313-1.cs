	public static void Main()
	{
		for (var i = 0; i < int.MaxValue; i++) {
			Console.WriteLine(Math.Round(1.2, MidpointRounding.AwayFromZero));
			Console.WriteLine(Math.Round(1.5, MidpointRounding.AwayFromZero));
			Console.WriteLine(Math.Round(-1.2, MidpointRounding.AwayFromZero));
			Console.WriteLine(Math.Round(-1.5, MidpointRounding.AwayFromZero));
		}
	}
