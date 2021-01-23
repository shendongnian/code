        public class RootObject
        {
            [JsonProperty("activities-heart")]
            public List<ActivitiesHeart> ActivitiesHeart { get; set; }
            [JsonProperty("activities-heart-intraday")]
            public ActivitiesHeartIntraday ActivitiesHeartIntraday { get; set; }
        }
