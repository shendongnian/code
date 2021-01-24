    public class Specifications
    {
        [JsonProperty("name1")]
        public string CodeModel { get; set; }
        [JsonProperty("name2")]
        private string CodeModel2 { set { CodeModel = value; } }
    }
