    MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("{connection-string-of-your-cosmosdb}"));
    settings.SslSettings = new SslSettings()
    {
        EnabledSslProtocols = SslProtocols.Tls12,
        ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            foreach (var element in chain.ChainElements)
            {
                // Gets the error status of the current X.509 certificate in a chain.
                foreach (var status in element.ChainElementStatus)
                {
                    Console.WriteLine($"certificate subject: {element.Certificate.Subject},ChainStatus: {status.StatusInformation}");
                }
            }
            return true; //just for dev, it would bypass certificate errors
        }
    };
    var mongoClient = new MongoClient(settings);
