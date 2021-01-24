    public class AzureSearchResponse
    {
        [JsonProperty("@odata.context")]
        public string ODataContext { get; set; }
        public List<SearchResult> value { get; set; }
    }
