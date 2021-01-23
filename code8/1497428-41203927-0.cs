    public async Task GetSummonerInformationAsync()
    {
      try
      {
        HttpResponseMessage response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string result = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<Dictionary<string, App2.Models.SummonerDto>>(result);
        ...
        System.Diagnostics.Debug.WriteLine("{0} this is the  {1}", data.First().Value.name, data.First().Value.profileIconId);
      }
      catch(Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.Message);
      }
    }
