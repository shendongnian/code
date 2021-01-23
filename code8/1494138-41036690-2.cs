	public HttpResponseMessage CreateMessage(Stream input)
	{
		HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
		result.Content = new StreamContent(input);
		return result;
	}
