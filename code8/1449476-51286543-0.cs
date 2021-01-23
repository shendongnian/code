    var myData = new { myvar = "my string", data = new[] {1,2,3,4,5}};
    
    var httpClient = new HttpClient(new HttpClientHandler());
    
    var jsonObject = JsonConvert.SerializeObject(myData)
    var stringContent = new StringContent(jsonObject.ToString(), System.Text.Encoding.UTF8, "application/json");
    
    HttpResponseMessage response = await httpClient.PostAsync(urlSaveRegions, stringContent);
    response.EnsureSuccessStatusCode();
    
    string data = await response.Content.ReadAsStringAsync();
