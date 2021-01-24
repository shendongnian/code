    public async Task<ActionResult> TestSSN()
	{
		var apiResponse = await GetUsTraceApiHealthAsync();
		return Json(apiResponse, JsonRequestBehavior.AllowGet);
	}
    public async Task<string> GetUsTraceApiHealthAsync()
	{
		using (HttpClient httpClient = new HttpClient())
		{
			string uri = $"https://trace.{ConfigHelper.SterlingDomain}health?deep";
			return apiResponse = await httpClient.GetStringAsync(uri);
		}
	}
