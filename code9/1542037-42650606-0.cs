    class News
    {
        [JsonProperty("ID")]
        public int id { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("PublishingDate")]
        public DateTime Date { get; set; }
        [JsonProperty("News")]
        public string Content { get; set; }
    }
