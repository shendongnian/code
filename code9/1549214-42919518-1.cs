	public static async Task<RootObject> GetAsync()
	{
		using (var client = new WebClient())
		{
            client.Headers["User-Agent"] = "something";
			var json = await client.DownloadStringTaskAsync(@"http://api.promasters.net.br/cotacao/v1/valores");
			var root = JsonConvert.DeserializeObject<RootObject>(json);
			return root;
		}	
	}
		
