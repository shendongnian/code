	static async void Main(string[] args)
	{
		while (true)
		{
			await Task.Delay(TimeSpan.FromSeconds(1.0));
			string signal = ReadGraph(driver, webElement);
			if (signal == "blue")
			{
				await RunAsync(signal);
			}
			if (signal == "green")
			{
				await RunAsync(signal);
			}
		}
	}
