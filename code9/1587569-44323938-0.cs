	[Route("{id}")]
	public async Task<HttpResponseMessage> Get(string id)
	{
		using (var client = new HttpClient())
		{
			client.BaseAddress = new Uri($"https://....../v1/accounts/");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string responseContent = await client.GetStringAsync($"{id}/summary");
			var response =
				new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent(responseContent)};
			return response;
		}
	}
