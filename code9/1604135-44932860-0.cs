    //Handle TLS protocols
    System.Net.ServicePointManager.SecurityProtocol =
        System.Net.SecurityProtocolType.Tls
        | System.Net.SecurityProtocolType.Tls11
        | System.Net.SecurityProtocolType.Tls12;
    var client = new HttpClient();
    client.BaseAddress = new Uri("https://myapi");
    //...
    var result = await client.PostAsync(method, httpContent);
