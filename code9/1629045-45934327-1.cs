    X509Certificate2 certificate = new X509Certificate2(certName, password);
    
    var Thumbprint = certificate.Thumbprint.ToString();
    
    Console.WriteLine($"client certificate Thumbprint: {Thumbprint}");
    
    WebRequestHandler requestHandler = new WebRequestHandler();
    
    requestHandler = new WebRequestHandler { ClientCertificateOptions = ClientCertificateOption.Manual };
    requestHandler.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
    
    requestHandler.ClientCertificates.Add(certificate);
    
    
    using (var client = new HttpClient(requestHandler))
    {   
        HttpResponseMessage response = await client.GetAsync("https://127.0.0.1:9527/test/5");
    
        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Received response: {content}");
        }
        else
        {
            Console.WriteLine($"Error, received status code {response.StatusCode}: {response.ReasonPhrase}");
        }
    }
