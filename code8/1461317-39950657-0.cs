    public  static int ReadFromConsole()
	{
		int i;
		while (true)
		{
			var line = Console.ReadLine();
			if (int.TryParse(line, out i)) break;
			Console.WriteLine("Invalid number.");
		}
		return i;
	}
