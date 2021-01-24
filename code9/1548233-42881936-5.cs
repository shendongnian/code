    public class VkCountry
    {
        public int Id { get; }
        public string Title { get; }
        public VkCountry(int countryId, string countryTitle) {
            this.Id = countryId;
            this.Title = countryTitle;
        }
    }
    
    public async Task<List<VkCountry>> FetchAsync(string url)
    {
        string jsonString;
        using (var httpClient = new System.Net.Http.HttpClient())
        {
            var stream = await httpClient.GetStreamAsync(url);
            StreamReader reader = new StreamReader(stream);
            jsonString = reader.ReadToEnd();
    
            var listOfCountries = new List<VkCountry>();
    
            var responseCountries = JArray.Parse(JObject.Parse(jsonString)["response"]["items"].ToString());
    
            foreach (var countryInResponse in responseCountries) {
                var vkCountry = new VkCountry((int)countryInResponse["id"], (string)countryInResponse["title"]);
    
                listOfCountries.Add(vkCountry);
            }
    
            return listOfCountries;
        } 
    }
