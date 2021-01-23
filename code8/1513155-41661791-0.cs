    public string start()
    {
        var response = sendRequest();
        Task<String> t = sendRequest();
        System.Diagnostics.Debug.WriteLine(t.Result);
    
        return "";
    }
    
    public async Task<string> sendRequest()
    {
         using (var client = new HttpClient())
         {
              var values = new Dictionary<string, string>
              {
                   { "vote", "true" },
                   { "slug", "the-slug" }
              };
    
              var content = new FormUrlEncodedContent(values);
    
              var response = await client.PostAsync("URL/api.php", content);
    
              var responseString = await response.Content.ReadAsStringAsync();
    
              return responseString;
          }
    
    }
