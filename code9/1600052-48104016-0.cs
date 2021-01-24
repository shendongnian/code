    static void coinMarketCap()
        {
           
            string json = new WebClient().DownloadString("https://api.coinmarketcap.com/v1/ticker/bitcoin/");
            
            List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
            Console.WriteLine("ID: " +items[0].id.ToUpper());
            Console.WriteLine("Name: " + items[0].name.ToUpper());
            Console.WriteLine("Symbol: " + items[0].symbol.ToUpper());
            Console.WriteLine("Rank: " + items[0].rank.ToUpper());
            Console.WriteLine("Price (USD): " + items[0].price_usd.ToUpper());
        }
        public class Item
        {
            public string id { get; set; }
            public string name { get; set; }
            public string symbol { get; set; }
            public string rank { get; set; }
            public string price_usd { get; set; }
            [JsonProperty(PropertyName = "24h_volume_usd")]   //since in c# variable names cannot begin with a number, you will need to use an alternate name to deserialize
            public string volume_usd_24h { get; set; }
            public string market_cap_usd { get; set; }
            public string available_supply { get; set; }
            public string total_supply { get; set; }
            public string percent_change_1h { get; set; }
            public string percent_change_24h { get; set; }
            public string percent_change_7d { get; set; }
            public string last_updated { get; set; }
        }
