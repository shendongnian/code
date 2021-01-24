    private readonly RestClient _client;
    
    public RestApiClient(string apiAdress)
    {
        _client = new RestClient(apiAdress);
        _client.AddHandler("application/json", NewtonsoftJsonSerializer.Default);
    }
    
