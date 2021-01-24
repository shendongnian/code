	public static class MockDownloader
	{
		static Random rnd = new Random();
		public async static Task<string> Download(string url)
		{
			if (url == "hanging")
				// wait for 5 seconds
				await Task.Delay(TimeSpan.FromSeconds(2));
			else
				// wait for 500 to 700 ms
				await Task.Delay(TimeSpan.FromMilliseconds(500 + rnd.Next(0, 200)));
	
			return $"{url} done";
		}
	}
