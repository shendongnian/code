    public StackOverflow Parse(string json)
    {
        StackOverflow response = new StackOverflow();
        response.Items = new List<Info>();
        
        dynamic res = JsonConvert.DeserializeObject(json);
        response.StatusCode = res.StatusCode;
    
        foreach (JProperty item in res)
        {
            
            if (item.Name != "StatusCode")
            {
                var infoItem = JsonConvert.DeserializeObject<Info>(item.Value.ToString());
                response.Items.Add(infoItem);
            }
        }
    
    
        return response;
    }
