    public HttpResponseMessage CreateNewBug(NewBugRequest newBugRequest)
	{
		return _apiUrlToCreateNewBug.AllowAnyHttpStatus()
									.WithBasicAuth("", _personalAccessTokenForBasicAuth)
									.PostAsync(new StringContent(JsonConvert.SerializeObject(newBugRequest.Fields), Encoding.UTF8, "application/json-patch+json"))
									.Result;
	}
