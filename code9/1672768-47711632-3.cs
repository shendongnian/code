    using(var client = newHttpClient())  
    {  
        client.BaseAddress = newUri("http://localhost:55587/");  
        client.DefaultRequestHeaders.Accept.Clear();  
        client.DefaultRequestHeaders.Accept.Add
                  (newMediaTypeWithQualityHeaderValue("application/json"));  
        //GET Method  
        HttpResponseMessage response = 
                  await client.GetAsync("GetAllRows/1/1/1/1");  
        if (response.IsSuccessStatusCode)  
        {  
        }  
    }  
