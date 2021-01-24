	private static void Calculate()
	{
		int x = 1;
		for (int i = 0; i < Program.IterationCount; i++)
		{
			Program.a = x + 2;
			Program.b = x - 2;
			Program.c = x * 2;
			Program.d = x / 2;
		}
	}
