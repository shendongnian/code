    string uri = "/api/Report";
    string token = "<token here>";
    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("<base address>");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri);
    request.Headers.Add("Authorization", string.Format("bearer {0}", token);
    
    HttpResponseMessage response = client.SendAsync(request).Result;
