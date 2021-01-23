    public class ListMaker
        {
            public List<Country> GetCountyList()
            {
                return GetCountryListAsync().Result;
            }
            private async Task<List<Country>> GetCountryListAsync()
            {
                var result = new List<Country>();
                var task =
                    await GetRequestAsync(@"http://api.vk.com/method/database.getCountries?need_all=1&v=5.60");
    
                var vk = JObject.Parse(task);
    
                foreach (var jsonCountry in vk["response"]["items"])
                    result.Add(JsonConvert.DeserializeObject<Country>(jsonCountry.ToString()));
                return result;
            }
    
            private async Task<string> GetRequestAsync(string url)
            {
                using (var httpClient = new HttpClient())
                    return await httpClient.GetStringAsync(url);
            }
    
            public class Country
            {
                public int Cid { get; set; }
                public string Title { get; set; }
    
                public new string ToString()
                {
                    return Title;
                }
            }
        }
