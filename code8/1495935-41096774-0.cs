    try
    {
		if (_httpClient == null)
        {
		   _httpClient = new HttpClient { BaseAddress = new Uri(yourWebSiteUrl) };
	    }
        var stringContentInput = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(new Uri(yourWebSiteUrl. + apiUrl), stringContentInput);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.StatusCode.ToString());
        }
        var stringAsync = await response.Content.ReadAsStringAsync();
        LoggingManager.Error("Received error response: " + stringAsync);
        return stringAsync;
    }
    catch (Exception exception)
    {
        return null;
    }
 }
