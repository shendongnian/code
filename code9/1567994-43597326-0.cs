    private static void Main()
    {
          var httpClient = new HttpClient(new MyTestHandler(new HttpClientHandler()));
    
          var response = httpClient.GetAsync("http://icanhazip.com/").Result;
    
          Console.WriteLine(response.Content.ReadAsStringAsync().Result);
    }
    
    
    private class MyTestHandler : DelegatingHandler
    {
    
          public MyTestHandler( HttpClientHandler handler) {
                base.InnerHandler = handler;
          }
    
          protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
          {  
                return await base.SendAsync(request, cancellationToken);
          }
    
    }
