	IDisposable subscription =
		Observable
			.Timer(DateTimeOffset.UtcNow.AddDays(1.0).Date, TimeSpan.FromDays(1.0))
			.Subscribe(x =>
			{
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("Run.");
				Console.ResetColor();
			});
