    using(var client = newHttpClient())  
    {  
        client.BaseAddress = newUri("http://localhost:55587/");  
        client.DefaultRequestHeaders.Accept.Clear();  
        client.DefaultRequestHeaders.Accept.Add(newMediaTypeWithQualityHeaderValue("application/json"));  
        //GET Method  
        HttpResponseMessage response = awaitclient.GetAsync("api/Department/1");  
        if (response.IsSuccessStatusCode)  
        {  
        }  
    }  
 
