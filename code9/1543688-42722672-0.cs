    var handler = new System.Net.Http.HttpClientHandler();
    using (var httpClient = new System.Net.Http.HttpClient(handler))
    {
        handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
        {
            // Log it, then use the same answer it would have had if we didn't make a callback.
            Console.WriteLine(cert);
            return errors == SslPolicyErrors.None;
        };
        ...
    }
