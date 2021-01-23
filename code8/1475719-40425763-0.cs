        public class MyFeed
        {
            [JsonProperty(PropertyName = "@Provider")]
            public string Provider { get; set; }
            public MMM MMM { get; set; }
        }
        public class RootJsonObject
        {
            public MyFeed MyFeed { get; set; }
        }
        public class MMM
        {
            [JsonProperty(PropertyName = "@name")]
            public string name { get; set; }
            public string provider { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string change { get; set; }
            public string pctchange { get; set; }
            public string ask { get; set; }
            public string bid_time { get; set; }
            public string bid { get; set; }
        }
