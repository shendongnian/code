	[Route("{id}")]
	public async Task<HttpResponseMessage> Get(string id)
	{
		using (var client = new HttpClient())
		{
			client.BaseAddress = new Uri($"https://....../v1/accounts/");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			
			// Fetch the response body as a string
			// Resource URI added below
			string responseContent = await client.GetStringAsync($"{id}/summary");
			
			// Create our response object and set the content to its StringContent
			var response =
				new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent(responseContent)};
				
			// Return our HttpResponseMessage containing our json text
			return response;
		}
	}
