    var spHandler = new HttpClientHandler()
    {
      ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
      {
        Console.WriteLine($"Sender: {sender}");
        Console.WriteLine($"cert: {cert}");
        Console.WriteLine($"chain: {chain}");
        Console.WriteLine($"sslPolicyErrors: {sslPolicyErrors}");
        return true;
      }
    };
    
    var spClient = new HttpClient(spHandler);
    spClient.BaseAddress = new Uri("https://10.0.0.24");
    var spRequest = new HttpRequestMessage(HttpMethod.Get, "/api/controller/");
    spRequest.Headers.Host = "somehost.com";
    var spResponse = await spClient.SendAsync(spRequest);
