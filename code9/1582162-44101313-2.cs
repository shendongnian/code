	public static void Main()
	{
		for (var i = 0; i < int.MaxValue; i++) {
			Console.WriteLine(Round(1.2));
			Console.WriteLine(Round(1.5));
			Console.WriteLine(Round(-1.2));
			Console.WriteLine(Round(-1.5));
		}
	}
	
	public static int Round(double num)
	{
		return num >= 0 ? (int)(num + 0.5f) : (int)(num - 0.5f);
	}
