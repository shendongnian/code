        public class RootObject
        {
            [JsonProperty("activities-heart")]
            public List<ActivitiesHeart> A { get; set; }
            [JsonProperty("activities-heart-intraday")]
            public ActivitiesHeartIntraday B { get; set; }
        }
