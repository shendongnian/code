    var httpClient =  new HttpClient(new NativeMessageHandler());
    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    var responseMessage = await httpClient.GetAsync("some/api/endpoint/here");
    if (!responseMessage.IsSuccessStatusCode)
    {
    	if (responseMessage.IsUnauthorized()) { // some handling here }
    }
    // time to get the result
    var res = await responseMessage.Content.ReadAsStringAsync();
    var obj = JsonConvert.DeserializeObject<Object>(res);
