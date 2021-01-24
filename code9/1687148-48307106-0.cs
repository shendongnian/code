    async Task CallerMethod()
	{
		JObject result = await GetToBackOffice(...);
		// Do something with result
	}
	
	internal static Task<JObject> GetToBackOffice(string action)
	{
		var tsc = new TaskCompletionSource<JObject>();
		var url = backOfficeUrl;
		url = url + action;
	
		HttpClient httpClient = new HttpClient();
	
		JObject idProcess = new JObject();
	
		httpClient.GetString(new Uri(url),
			(response) =>
			{
				// Raised when the download completes
				if (response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					tsc.SetResult(Newtonsoft.Json.Linq.JObject.Parse(response.Data));
				}
				else
				{
					tsc.SetResult(null);
				}
			});
	
		return tsc.Task;
	}
