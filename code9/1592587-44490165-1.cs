    XDocument GetSecureXDocument(string url)
    {
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        var client = new WebClient
        {
            Headers = { [HttpRequestHeader.Accept] = "application/xml" }
        };
        using (var stream = client.OpenRead(url))
            return XDocument.Load(stream);
    }
