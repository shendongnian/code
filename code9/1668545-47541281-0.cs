    class Program
    {
        static void Main(string[] args)
        {
            // returns Newtonsoft.Json.Linq.JArray
            var coinMarket = Newtonsoft.Json.JsonConvert.DeserializeObject(File.ReadAllText("get.json"));
            Console.WriteLine(coinMarket.GetType());
            // returns array of CoinData
            var coinMarketTyped = Newtonsoft.Json.JsonConvert.DeserializeObject<CoinData[]>(File.ReadAllText("get.json"));
            Console.WriteLine(coinMarketTyped.GetType());
            // returns List of CoinData
            var coinMarketTyped2 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CoinData>>(File.ReadAllText("get.json"));
            Console.WriteLine(coinMarketTyped2.GetType());
        }
    }
    public class CoinData
    {
        public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string rank { get; set; }
        public string price_usd { get; set; }
        public string price_btc { get; set; }
        public string __invalid_name__24h_volume_usd { get; set; }
        public string market_cap_usd { get; set; }
        public string available_supply { get; set; }
        public string total_supply { get; set; }
        public string percent_change_1h { get; set; }
        public string percent_change_24h { get; set; }
        public string percent_change_7d { get; set; }
        public string last_updated { get; set; }
    }
