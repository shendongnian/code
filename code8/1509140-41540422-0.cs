    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    namespace radacodeTestApp
    {
    public class ListsDownloader
    {
        public List<Country> Countries { get; private set; }
        public ListsDownloader()
        {
            Countries = new List<Country>();
            Task.Run(async () => await DownloadCountriesListAsync());
        }
        public async Task<bool> DownloadCountriesListAsync()
        {
            try
            {
                var vkjsonResponse = await GetResponse(@"https://api.vk.com/api.php?oauth=1&method=database.getCountries&need_all=1&v=5.60");
                var jsonObject = JObject.Parse(vkjsonResponse);
                foreach (var jO in jsonObject["response"]["items"])
                    Countries.Add(JsonConvert.DeserializeObject<Country>(jO.ToString()));
                
            }
            catch (OperationCanceledException)
            {
                return false;
            }
            return true;
        }
        public async Task<string> GetResponse(string url)
        {
            using (var httpClient = new HttpClient())
                return await httpClient.GetStringAsync(url);
   
        }
       
    }
    public class Country
    {
        public int Cid { get; set; }
        public string Title { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}
