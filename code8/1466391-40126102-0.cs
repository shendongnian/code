    protected HttpClient SetupHttpClient(string uri)
    {
       HttpClient client = new HttpClient {BaseAddress = uri};
       client.DefaultRequestHeaders.Accept.Clear();            
       client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
       return client;
    }   
