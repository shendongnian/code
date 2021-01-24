    public class BinanceKlineData
    {
        [JsonProperty(Order = 1)]
        public long OpenTime { get; set; }
        [JsonProperty(Order = 2)]
        public decimal Open { get; set; } // Or string, if you prefer
        [JsonProperty(Order = 3)]
        public decimal High { get; set; } // Or string, if you prefer
        [JsonProperty(Order = 4)]
        public decimal Low { get; set; } // Or string, if you prefer
        [JsonProperty(Order = 5)]
        public decimal Close { get; set; } // Or string, if you prefer
        [JsonProperty(Order = 6)]
        public decimal Volume { get; set; } // Or string, if you prefer
        [JsonProperty(Order = 7)]
        public long CloseTime { get; set; }
        [JsonProperty(Order = 8)]
        public decimal QuoteAssetVolume { get; set; } // Or string, if you prefer
        [JsonProperty(Order = 9)]
        public long NumberOfTrades { get; set; } // Should this be an long or a decimal?
        [JsonProperty(Order = 10)]
        public decimal TakerBuyBaseAssetVolume { get; set; }
        [JsonProperty(Order = 11)]
        public decimal TakerBuyQuoteAssetVolume { get; set; }
        // public string Ignore { get; set; }
    }
