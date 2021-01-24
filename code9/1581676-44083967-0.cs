         public class ObjectData
        {
            public int id { get; set; }
            public string last { get; set; }
            public string lowestAsk { get; set; }
            public string highestBid { get; set; }
            public string percentChange { get; set; }
            public string baseVolume { get; set; }
            public string quoteVolume { get; set; }
            public string isFrozen { get; set; }
            public string high24hr { get; set; }
            public string low24hr { get; set; }
        }
        public class RootObject
        {
            public ObjectData BTC_BCN { get; set; }
            public ObjectData BTC_BELA { get; set; }
            public ObjectData BTC_BLK { get; set; }
        }
