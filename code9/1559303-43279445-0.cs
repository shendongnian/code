    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("http://10.0.2.2:19367/api/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    HttpResponseMessage response = client.GetAsync("APICustAccount/getTestData").Result;
    if (response.StatusCode == HttpStatusCode.OK)
    {
        var result = await response.Content.ReadAsStringAsync();
        var todoItems = JsonConvert.DeserializeObject<List<CustomerApp>>(result);
    }
