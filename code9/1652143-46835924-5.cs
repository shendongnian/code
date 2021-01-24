    public class RootJsonObject
    {
        [JsonProperty("cr_response")]
        public CrResponse CrResponse { get; set; }
    }
    
    public class CrResponse
    {
        [JsonProperty("cr_metadata")]
        public CrMetadata CrMetadata { get; set; }
    
        [JsonProperty("details")]
        public Detail[] Details { get; set; }
    }
    
    public class CrMetadata
    {
    }
    
    public class Detail
    {
        [JsonProperty("fields")]
        public Field[] Fields { get; set; }
    
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    
    public class Field
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    
        [JsonProperty("value")]
        public string Value { get; set; }
    }
