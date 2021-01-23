    // Query string parameters
    var queryString = new Dictionary<string, string>()
    {
        { "foo", "bar" }
    };
    
    // Create json for body
    var content = new JObject(json);
    
    // Create HttpClient
    var client = new HttpClient();
    client.BaseAddress = new Uri("https://api.baseaddress.com/");
    
    // This is the missing piece
    var requestUri = QueryHelpers.AddQueryString("something", queryString);
    var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
    // Setup header(s)
    request.Headers.Add("Accept", "application/json");
    // Add body content
    request.Content = new StringContent(
        content.ToString(),
        Encoding.UTF8,
        "application/json"
    );
       
    // Send the request
    client.SendAsync(request);
