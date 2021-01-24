        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("xxx", "xxx");
        client.DefaultRequestHeaders.Add("xxx", xxx);
        HttpContent content = new StringContent("");
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await client.PostAsync("https://blabla/bla/", content);
 
        response.EnsureSuccessStatusCode();
 
        string json = await response.Content.ReadAsStringAsync();
        var br = JsonConvert.DeserializeObject<List<Things>>(json);
        return br;
