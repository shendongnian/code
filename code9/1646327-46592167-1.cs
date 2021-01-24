    string Baseurl = "http://localhost:62602/";
    client.BaseAddress = new Uri(Baseurl);
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    var response = await client.GetAsync("api/FileSearch/?searchTerm=" + searchTerm );
    if (response.IsSuccessStatusCode) {
        var json = await response.Content.ReadAsStringAsync();
        RootObject searchData = JsonConvert.DeserializeObject<RootObject>(json);
        //...
    }
