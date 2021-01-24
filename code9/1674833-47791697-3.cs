    using (var client = new HttpClient())  
    {  
      HttpResponseMessage response = await client.GetAsync("url");  
      response.EnsureSuccessStatusCode();  
      using (HttpContent content = response.Content)  
      {  
        string responseBody = await response.Content.ReadAsStringAsync();  
        var obj = JsonConvert.DeserializeObject<Mobile_SettingModels>(responseBody);  
    
      }
    }
