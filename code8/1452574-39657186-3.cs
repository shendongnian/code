    public async Task<string> PostAsync(string apiCall, HttpContent data)
    {
       var client = new HttpClient();
       try
       {
          var response = await client.PostAsync(apiCAll, data);
          return await response.Content.ReadAsStringAsync();
       }
       catch (Exception ex)
       {
          // do something
       }
    }
