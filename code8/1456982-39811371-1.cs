	public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
	{
		SetupHttpClient();
		return _httpClient.SendAsync(request);
	}
	public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
	{
		SetupHttpClient();
		return _httpClient.SendAsync(request, completionOption, cancellationToken);
	}
	HttpClient _httpClient;
	void SetupHttpClient()
	{
		if (_httpClient == null)
		{
			_httpClient = new HttpClient();
			var accessToken = _account.Properties["access_token"];
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
		}
	}
