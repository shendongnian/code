        const string loginUri = "https://some.website/login";
        var cookieContainer = new CookieContainer();
        var clientHandler = new HttpClientHandler() 
        { 
            CookieContainer = cookieContainer, 
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate 
        };
        var client = new HttpClient(clientHandler);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        // First do a GET to the login page, allowing the server to set certain 
        // required cookie values.
        var initialGetRequest = new HttpRequestMessage(HttpMethod.GET, loginUri);
        await client.SendAsync(initialGetRequest);
        var loginRequest = new HttpRequestMessage(HttpMethod.Post, loginUri);
        // These form values correspond with the values posted by the browser
        var formContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("customercode", "password"),
            new KeyValuePair<string, string>("customerid", "username"),
            new KeyValuePair<string, string>("HandleForm", "Login")
        });
        loginRequest.Content = formContent;
        loginRequest.Headers.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.79 Safari/537.36 Edge/14.14393");
        loginRequest.Headers.Referrer = new Uri("https://some.website/Login?ReturnUrl=%2f");
        loginRequest.Headers.Host = "some.website";
        loginRequest.Headers.Connection.Add("Keep-Alive");
        loginRequest.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue() { NoCache = true };
        loginRequest.Headers.AcceptLanguage.ParseAdd("nl-NL");
        loginRequest.Headers.AcceptEncoding.ParseAdd("gzip, deflate");
        loginRequest.Headers.Accept.ParseAdd("text/html, application/xhtml+xml, image/jxr, */*");
        var response = await client.SendAsync(loginRequest);
        var responseString = await response.Content.ReadAsStringAsync();
        var cookies = cookieContainer.GetCookies(new Uri(loginUri));
