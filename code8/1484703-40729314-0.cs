    using (HttpClient client = new HttpClient())
    {
        client.DefaultRequestHeaders.Add("X-Parse-Application-Id", "****");
        client.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", "****");
        var response = await client.PostAsync("https://parseapi.back4app.com/classes/Usuarios", new StringContent("{\"Usuario\":\"Luis\"}"));    
    }
