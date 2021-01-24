        public class SearchShim
        {
            [JsonProperty("header", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
            public SearchHeader AllUrls { get; set; }
            
            public List<Search> Searches {get;set;}
        }
