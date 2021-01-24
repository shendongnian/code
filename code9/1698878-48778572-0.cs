    public class AddResult
    {
        [JsonProperty("objectId")]
        public int objectId { get; set; }
        [JsonProperty("globalId")]
        public string globalId { get; set; }
        [JsonProperty("success")]
        public bool success { get; set; }
    }
    public class Attachments
    {
        [JsonProperty("addResults")]
        public List<object> addResults { get; set; }
        [JsonProperty("deleteResults")]
        public List<object> deleteResults { get; set; }
        [JsonProperty("updateResults")]
        public List<object> updateResults { get; set; }
    }
    public class ApplyEditsResult
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("addResults")]
        public List<AddResult> addResults { get; set; }
        [JsonProperty("attachments")]
        public Attachments attachments { get; set; }
    }
