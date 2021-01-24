    var handler = new HttpClientHandler();
        handler.ClientCertificateOptions = ClientCertificateOption.Manual;
        handler.SslProtocols = SslProtocols.Tls12;
        handler.ClientCertificates.Add(new X509Certificate2("<partner>.crt", key));
        var client = new HttpClient(handler);
        var result = client.GetAsync("https://APIDomain/returns/?wsdl").GetAwaiter().GetResult();
