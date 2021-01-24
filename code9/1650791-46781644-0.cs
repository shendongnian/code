    HttpClient client = new HttpClient();
    client.BaseAddress = @"http://[YourBaseUri]/";
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    var request = client.GetAsync("[YourActionName]");
    return request.Result.Content.ReadAsStringAsync().Result;
