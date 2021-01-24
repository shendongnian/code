    var url = "http://someurl";
    using (var client = new HttpClient())
    using (var response = await client.GetAsync(url))
    using (var content = response.Content)
    {
        var result = await content.ReadAsStringAsync();
        // examine the response
    }
