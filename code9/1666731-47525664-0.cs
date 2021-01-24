    public string GetWeather(string info)
        {
            string results = "";
            using (WebClient wc = new WebClient())
            {
                results = wc.DownloadString("https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%27galati%2C%20ro%27)%20and%20u%3D%22c%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
            }
            dynamic jo = JObject.Parse(results);
            if (info == "cond")
            {
                var items = jo.query.results.channel.item.condition;
                condition = items.text;
                return condition;
            }
        }
