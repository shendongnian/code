    private void CallService(bool sample)
    {
        client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("BaseWebApiUrl"));
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
        var apiUrl = $"http://yourserver:port/api/somecontroller/?sample={sample}";
    
        var Context = new StringContent(JsonConvert.SerializeObject(parameter), Encoding.UTF8, "application/json");
    
        var respFeed = await client.PostAsync(apiUrl, Context);
    }
