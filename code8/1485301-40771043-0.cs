    // var RequestType content <- this is an input parameter. 
    var request = new HttpRequestMessage()
    {
        RequestUri = new Uri(@"http://test/" + yourControllerUri),
        Method = HttpMethod.Post,
    };
    
    request.Headers.Add("YourHeaderName", "YourHeaderValue");
    request.Content = new ObjectContent<RequestType>(content, new JsonMediaTypeFormatter());
    
    var result = _client.SendAsync(request).Result;
