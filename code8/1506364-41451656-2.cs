    public class Cuisine
    {
        [JsonProperty("cuisine")]
        public CuisineData data { get; set; }
    }
    public class CuisineData
    {
        [JsonProperty("cuisine_id")]
        public string cuisine_id { get; set; }
        [JsonProperty("cuisine_name")]
        public string cuisine_name { get; set; }
    }
    public class Cuisines
    {
        [JsonProperty("cuisines")]
        public List<Cuisine> AllCuisines { get; set; } 
    }
