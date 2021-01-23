    try
    {
        HttpClient cl = new HttpClient();
        cl.BaseAddress = new Uri("http://localhost:35936");
        cl.DefaultRequestHeaders.Add("ApiUser", "User");
        cl.DefaultRequestHeaders.Add("Password", "Password");
        cl.DefaultRequestHeaders.Add("MyVar", "1234");
        cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));               
        string json = JsonConvert.SerializeObject(testedVar);
        var sucSender = await cl.PostAsJsonAsync("api/sender/successtested", json);
        if (sucSender.IsSuccessStatusCode)
        {
            var newvar = await sucSender.Content.ReadAsAsync<Tested>();                     
        } 
    }
