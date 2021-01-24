    //have a cookie container before making the request
    var cookies = new CookieContainer();
    var handler = new HttpClientHandler() {
        AllowAutoRedirect = true,
        CookieContainer = cookies,
        AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
    };
    //Handle TLS protocols (https)
    System.Net.ServicePointManager.SecurityProtocol =
        System.Net.SecurityProtocolType.Tls
        | System.Net.SecurityProtocolType.Tls11
        | System.Net.SecurityProtocolType.Tls12;
    var client = new HttpClient(handler);
    client.DefaultRequestHeaders.TryAddWithoutValidation("UserAgent", "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:18.0) Gecko/20100101 Firefox/18.0");
    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
    client.DefaultRequestHeaders.TryAddWithoutValidation("KeepAlive", "true");
    client.DefaultRequestHeaders.TryAddWithoutValidation("ServicePoint.Expect100Continue", "false");
    var uri = new Uri("Link");
    var response = await client.GetAsync(uri);
    var html = await response.Content.ReadAsStringAsync();
    // Get the csrf token from response html
    var tokenValue = Regex.Match(html, "name='csrf_token' value='(.+?)'").Groups[1].Value;
    //...Prepare values to send
