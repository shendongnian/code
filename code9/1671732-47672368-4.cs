    using System.Net.Http;
    using Newtonsoft.Json;
    
    public async Task<LicensePlateInformation> GetLicensePlateInfoFromAPI()
    {
       try
       {
        string stringifiedJSONFromAPI = string.Empty;
        LicensePlateInformation plateInfo = new LicensePlateInformation();
        using(HttpClient client = new HttpClient())
        {
           client.DefaultRequestHeaders.Accept.Clear();
           client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
           HttpResponseMessage msg = await client.GetAsync($"<Insert rest api endpoint here>");
           
           if(msg.IsSuccessStatusCode)
           {
              stringifiedJSONFromAPI = await msg.Content.ReadAsStringAsync();
              JsonConvert.PopulateObject(stringifiedJSONFromAPI, plateInfo);
           }
           return plateInfo;
        }
       }
       catch(Exception ex)
       {
          throw;
       }
    }
