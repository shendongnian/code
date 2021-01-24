    private string _toolSystemKeyHeader;
    public ServiceProductDataProvider(string toolSystemKeyHeader)
    {
        _toolSystemKeyHeader = toolSystemKeyHeader
    }
    private HttpClient GetClientInstance()
    {
        HttpClient _client = new HttpClient();
        _client.DefaultRequestHeaders.Add(header, _toolSystemKeyHeader); //?? in your original code, the toolSystemKeyHeader is not used, but I guess it is the token..?
        return _client;
    }
