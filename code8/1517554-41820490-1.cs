	public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
	{
		return Task.Run(() =>
		{
			var rspContent = "here's a response string";
			var rsp = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
			if (!string.IsNullOrEmpty(rspContent))
			{
				rsp.Content = new StringContent(rspContent);
			}
			return rsp;
		}, cancellationToken);
	}
