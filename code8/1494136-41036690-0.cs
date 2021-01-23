	public HttpResponseMessage Post()
	{
		HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
		result.Content = new StreamContent(getInputStream());
		return result;
	}
