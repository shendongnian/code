	string timeFormat = "hh:mm tt";
	string Time = (new DateTime(1970, 1, 1, 0, 0, 0)).ToString(timeFormat); //12:00 AM
	while (true)
	{
		if (Time == DateTime.UtcNow.ToString(timeFormat))
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("Run.");
			Console.ResetColor();
			Thread.Sleep(120000);
		}
		Thread.Sleep(1);
	}
