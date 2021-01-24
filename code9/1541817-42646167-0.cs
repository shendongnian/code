        public class Context {
        [JsonProperty("@vocab")] //This is to map the property name with @symbol in JSON content to this class property
         public string vocab { get; set; }
         public string goog { get; set; }
         public string EntitySearchResult { get; set; }
         public string detailedDescription { get; set; }
         public string resultScore { get; set; }
         public string kg { get; set; }
        }
        public class DetailedDescription {
         public string articleBody { get; set; }
         public string url { get; set; }
         public string license { get; set; }
        }
        public class Result {
         [JsonProperty("@id")]
         public string id { get; set; }
         public string name { get; set; }
         [JsonProperty("@type")]
         public List<string> type { get; set; }
         public string description { get; set; }
         public DetailedDescription detailedDescription { get; set; }
        }
        public class ItemListElement {
         [JsonProperty("@type")]
         public string type { get; set; }
         public Result result { get; set; }
         public double resultScore { get; set; }
        }
        public class SearchResult {
         [JsonProperty("@context")]
         public Context context { get; set; }
         [JsonProperty("@type")]
         public string type { get; set; }
         public List<ItemListElement> itemListElement { get; set; }
        }
