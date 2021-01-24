    var client = new HttpClient();
    client.BaseAddress = new Uri("http://54.193.102.251/CBR/api");
    // here you can add additional information like authorization or accept headers
    client.DefaultRequestHeaders
       .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    var response = await client.GetAsync("User?EmpID=1&ClientID=4&Status=true");
    if (!response.IsSuccessStatusCode)
        return; // process error response here
    var json = await response.Content.ReadAsStringAsync(); // assume your API supports json
    // deserialize json here
