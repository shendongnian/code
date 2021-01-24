        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var client = new HttpClient();
            var result = client.GetAsync("https://www.ecfr.gov").Result;
            var str = result.Content.ReadAsStringAsync().Result;
        }
