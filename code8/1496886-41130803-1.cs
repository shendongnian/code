    	static void Main(string[] args)
	{
		Task.Run(async () =>
		{
			var toDownload = new string[] { "http://google.com", "http://microsoft.com", "http://apple.com" };
			var client = new HttpClient();
			var downloadedItems = await DownloadItems(client, toDownload);
			Console.WriteLine("This is async");
			foreach (var item in downloadedItems)
			{
				Console.WriteLine(item);
			}
			Console.ReadLine();
		}).Wait();
	}
	static async Task<IEnumerable<string>> DownloadItems(HttpClient client, string[] uris)
	{
        // This sets up each page to be downloaded using the same HttpClient.
		var items = new List<string>();	
		foreach (var uri in uris)
		{
			var item = await Download(client, uri);
			items.Add(item);
		}
		return items;
	}
	static async Task<string> Download(HttpClient client, string uri)
	{
        // This download the page and returns the content.
		if (string.IsNullOrEmpty(uri)) return null;
		var content = await client.GetStringAsync(uri);
		return content;
	}
