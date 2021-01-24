    var cert = new X509Certificate2(@"IDClient.pfx");
    var handler = new WebRequestHandler();
    handler.ClientCertificates.Add(cert);
    
    string tokenEndPoint = ConfigurationManager.AppSettings["TokenEndpoint"];
    
    var client = new TokenClient(
        tokenEndPoint,
        "cc.WithCertificate",
        handler);
    
    // Calling the Token Service
    var response = client.RequestClientCredentialsAsync("read").Result;
