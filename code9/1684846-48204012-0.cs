    class DF
    {
        // Other properties...
        [JsonConverter(typeof(FunnyListConverter))]
        public List<Content> content { get; set; }
    }
    class Content
    {
        public int DFID { get; set; }
    }
    class Invoice : Content
    {
    }
    class Receipt : Content
    {
    }
