    using (var client = new HttpClient()) {
        client.DefaultRequestHeaders.Add("myHeader", "value");
        using (var response = await client.GetAsync(page)) {        
           var result = await response.Content.ReadAsStringAsync();
        }
    }
