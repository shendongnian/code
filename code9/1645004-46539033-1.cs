    public static void parseJson()
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(@"https://thingspeak.com/channels/301726/field/1.json");
                JObject obj = JObject.Parse(json);
                foreach (var feedObj in obj["feeds"])
                 {
                     Feeds feed = JsonConvert.DeserializeObject<Feeds>(feedObj .ToString());
                     double feild1 = feed.field1;
                 }
            }
        } 
