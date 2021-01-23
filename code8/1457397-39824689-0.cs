    using System.Net.Https; // Add this library
    using (var client = new HttpClient())
    {
        var values = "DataToSend";
    
        var content = new FormUrlEncodedContent(values);
        var response = await client.PostAsync("http://sit.com/sample.aspx", content);
    
        var responseString = await response.Content.ReadAsStringAsync(); //JSON
    }
