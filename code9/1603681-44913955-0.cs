        string responseString = "";
        ...
            if (response.IsSuccessStatusCode)
            {
             responseString = response.Content.ReadAsStringAsync().Result;
             Message jsonObject = JsonConvert.DeserializeObject<Message>(responseString.ToString(), 
        new JsonSerializerSettings
        {
        NullValueHandling = NullValueHandling.Ignore
        });
            
            ...
    }    
 
  
