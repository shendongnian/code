        static void Main(string[] args)
        {
            /* Download the string */
            WebClient client = new WebClient();
            string json = client.DownloadString("https://freegeoip.net/json/37.57.106.53");
            Console.WriteLine("Returned " + json);
            /* We deserialize the string into our custom C# object. ToDo: Check for null return or exception. */
            var geoIPInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<GeoIPInfo>(json);
            /* Print out some info */
            Console.WriteLine(
                "We resolved the IP {0} to country {1}, which has the timezone {2}.",
                geoIPInfo.ip, geoIPInfo.country_name, geoIPInfo.time_zone);
            Console.ReadLine();
            return;
         }
