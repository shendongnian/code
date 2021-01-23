	private HttpMethod CreateHttpMethod(string method)
	{
		switch (method.ToUpper())
		{
			case "POST":
				return HttpMethod.Post;
			case "GET":
				return HttpMethod.Get;
			default:
				throw new NotImplementedException();
		}
	}
	public async Task<HttpResponseMessage> DoRequest(string url, HttpContent content, string method)
	{
		var request = new HttpRequestMessage(CreateHttpMethod(method), url)
		{
			Content = content
		};
		return await client.SendAsync(request);
	}
