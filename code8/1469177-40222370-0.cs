     class Program
        {
            static void Main(string[] args)
            {
                string json = "{\"google.com\":{\"target\":\"google.com\",\"0\":[94,73],\"1\":[94,73],\"2\":[94,73],\"4\":[93,67],\"categories\":{\"501\":99,\"301\":48,\"304\":5}},\"yahoo.com\":{\"target\":\"yahoo.com\",\"0\":[94,75],\"1\":[94,75],\"2\":[94,75],\"4\":[93,69],\"categories\":{\"501\":99,\"301\":16,\"304\":11}}}";
    
                Dictionary<string, dynamic> dictionary_data = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
                List<Website> sites = new List<Website>();
                foreach (var item in dictionary_data)
                {
                    string data = Convert.ToString(item.Value);
                    data = data.Replace("\r\n", string.Empty); ;
                    Website site = JsonConvert.DeserializeObject<Website>(data);
                    sites.Add(site);
                }
            }
        }
    
    
        public class Categories
        {
            [JsonProperty("401")]
            public int a { get; set; }
            [JsonProperty("501")]
            public int b { get; set; }
        }
        public class Website
        {
            public string target { get; set; }
    
            [JsonProperty("0")]
            public List<int> FirstList { get; set; }
    
            [JsonProperty("1")]
            public List<int> SecondList { get; set; }
    
            [JsonProperty("2")]
            public List<int> ThirdList { get; set; }
    
            [JsonProperty("4")]
            public List<int> FourList { get; set; }
            public Categories categories { get; set; }
        }
    
        public class RootObject
        {
            public Website domain_name { get; set; }
        }
