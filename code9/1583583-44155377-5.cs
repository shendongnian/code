    public class Item
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("uploaded")]
        public string Uploaded { get; set; }
        [JsonProperty("uploader")]
        public string Uploader { get; set; }
        //Etc...
    }
