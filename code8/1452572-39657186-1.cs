    public async Task<string> PostAsync(string apiCall, HttpContent data)
    {
       try
       {
          var response = await _client.PostAsync(apiCAll, data);
          return await response.Content.ReadAsStringAsync();
       }
       catch (Exception ex)
       {
          // do something
       }
    }
