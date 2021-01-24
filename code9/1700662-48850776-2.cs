    public async void Execute()
    {
    string query = $"<RequestData>" +
    $"<firstField>{model.firstField}</firstField>" +
    $"<secondField>{model.secondField}</secondField>" +
    $"<thirdField>{model.thirdField}</thirdField>" +
    	$"</RequestData>";
       using(HttpClient client = CreateClient())
       {
    	HttpResponseMessage response = await SendRequest(client, HttpMethod.Put, query);
       }
    }
    
    private HttpClient CreateClient()
    {
    var client = new HttpClient();
       client.BaseAddress = baseAdress;
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    return client;
    }
    
    private async Task<HttpResponseMessage> SendRequest(HttpClient httpClient, HttpMethod method, string query)
    {
    HttpRequestMessage request = new HttpRequestMessage(method, query);
    return await httpClient.SendAsync(request);
    }
    
