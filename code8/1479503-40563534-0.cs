    public class Openfda
    {     
        [JsonProperty("generic_name")]
        public List<string> GenericName { get; set; }
        [JsonProperty("brand_name")]
        public List<string> BrandName { get; set; }     
    }
    public class Result
    {
        [JsonProperty("openfda")]
        public Openfda Openfda { get; set; }   
    }
    public class Root
    {
        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }
