	private async Task<String> GetUrl(string url)
	{
		HttpClientHandler handler = new HttpClientHandler()
		{
			AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
		};
		HttpClient httpClient = new HttpClient(handler);
		string htmlresult = "";
		var response = await httpClient.GetAsync(url);
		if (response.IsSuccessStatusCode)
		{
			htmlresult = await response.Content.ReadAsStringAsync();
		}
		return htmlresult;
	}
