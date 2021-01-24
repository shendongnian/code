	DateTime Time = DateTime.UtcNow.AddDays(1.0).Date;
	while (true)
	{
		if (DateTime.UtcNow > Time)
		{
			Time = DateTime.UtcNow.AddDays(1.0).Date;
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("Run.");
			Console.ResetColor();
		}
		Thread.Sleep(1);
	}
