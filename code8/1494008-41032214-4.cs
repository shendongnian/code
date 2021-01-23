    public static HttpClient GetHttpClient()
    {
        var client = new HttpClient(new RetryHandler(new HttpClientHandler()));
    
        client.BaseAddress = new Uri("API URL");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
             new MediaTypeWithQualityHeaderValue("application/json"));
    
        var bcreds = Encoding.ASCII.GetBytes("Authorized Token Same As Server");
        var base64Creds = Convert.ToBase64String(bcreds);
        client.DefaultRequestHeaders.Add("Authorization", 
            "Basic " + base64Creds);
    
        return client;
    }
