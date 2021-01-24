    [JsonConverter(typeof(Converter))]
    class SearchResult
    {
        public Summary Summary { get; set; }
        public List<RelevanceWrapper> Relevances { get; set; }
    }
    class Summary
    {
        public string Page { get; set; }
        public string Relevancy { get; set; }
        public int Count { get; set; }
        public string Query { get; set; }
    }
    class RelevanceWrapper
    {
        public int Id { get; set; }
        public int Relevance { get; set; }
    }
