    private class MyTestHandler : DelegatingHandler
	{
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (someCondition)
			{
				base.InnerHandler = new MyHttpClientHandler(...);
			}
			else
			{
				base.InnerHandler = new MyOtherHttpClientHandler(...);
			}
			
			return await base.SendAsync(request, cancellationToken);
		}
	}
