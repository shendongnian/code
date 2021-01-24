        HttpMessageHandler handler = new HttpClientHandler
        {
             SslProtocols = System.Security.Authentication.SslProtocols.Tls12 | System.Security.Authentication.SslProtocols.Tls11 | System.Security.Authentication.SslProtocols.Tls,
             ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        };
