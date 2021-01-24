    public class AllAllergiesViewModel
    {
        public RootObject rootObject { get; set; }
        public async Task GetAllAllergies()
        {
            string json = await jsonResult("http://ec2-54-83-191-130.compute-1.amazonaws.com:8080/Sanjeevani/rest/SV/GetAllergy/" + factor.Passcode);
            this.rootObject = JsonConvert.DeserializeObject<RootObject>(json);
        }
        internal async Task<string> jsonResult(string url)
        {
            string data;
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            using (HttpContent content = response.Content)
            {
                data = await content.ReadAsStringAsync();
            }
            return data;
        }
    }
