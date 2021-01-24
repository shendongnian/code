    public async Task<HttpResponseMessage> GetJsonAsync<T>(Controllers controller, T data)
    {
        HttpResponseMessage response;
    
        using (var service = new MyService())
        {
           HttpClient http;
           string serviceLoc = service.GetServiceClient(controller, out http);
           response = await http.GetAsync(serviceLoc, data);
        }
    
        return response;
    }
