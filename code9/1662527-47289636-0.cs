    public class Orderbook
    {
        [JsonProperty("btc_usd")]
        public Currency BTCToUSD{ get; set; }
    }  
    
    public class Currency
    {
        [JsonProperty("asks")]
        public double[][] asks { get; set; }
    
        [JsonProperty("bids")]
        public double[][] bids { get; set; }
    }
    
    var jsonResponse = JsonConvert.DeserializeObject<Orderbook>(response);
