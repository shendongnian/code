    public class PageResponse
    {
        public string Page { get; set;}
        [JsonProperty("per_page")]
        public int PerPage { get; set;}
        public int Total { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        public IEnumerable<Movie> Data { get; set; }
    }
    public class Movie
    {
        public string Poster { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        [JsonProperty("imdbID")]
        public string ImdbId { get; set; }
    }
