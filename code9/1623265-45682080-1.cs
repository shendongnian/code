	public async Task<HttpResponseMessage> MakeRequest(Func<HttpResponseMessage> request)
	{
		var response = policy.ExecuteAsync(() => request.Invoke());
		return response;
	}
	public void MyMethodUsingAsync()
	{
		var responsePromises = MakeRequest(() => {...});
		///do some job wich will be done before response is retrieved (not waiting for it); and if you need it - use await
		var responseReceived = await responsePromises;
	}
