	async void Main()
	{
		using (var client = new HttpClient())
		{
			client.DefaultRequestHeaders.Add("Accept", "application/json");
			client.DefaultRequestHeaders.Add("User-Agent", "linqpad");
			
			var response = await client.GetAsync("http://api.promasters.net.br/cotacao/v1/valores");
			response.EnsureSuccessStatusCode();
	
			var container = await response.Content.ReadAsAsync<Container>();
            // do stuff with container...
		}
	}
