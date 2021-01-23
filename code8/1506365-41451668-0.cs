    public class Cuisine
    {
        [JsonProperty("cuisine_id")]
        public string cuisine_id { get; set; }
        [JsonProperty("cuisine_name")]
        public string cuisine_name { get; set; }
    }
    public class CuisineWrapper
    {
        public Cuisine cuisine { get; set; }
    }
    public class Cuisines
    {
        [JsonProperty("cuisines")]
        public List<CuisineWrapper> AllCuisines { get; set; }
    }
