    using (var client = new HttpClient())
    {
        var response = client.GetAsync("http://example.com").Result;
    
        if (response.IsSuccessStatusCode)
        {    
            string responseString = response.Content.ReadAsStringAsync().Result;
    
            Console.WriteLine(responseString);//you can save the responseString here
        }
    }
