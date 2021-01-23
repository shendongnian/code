    public class News
    {
        public string field { get; set; }
        public string sortBy { get; set; }
        public Article[] articles { get; set; }
    }
    public class Article
    {
        public string id { get; set; }
        public string title { get; set; }
        public string shortDescription { get; set; }
        public string urlToDescription { get; set; }
        public string urlToImage { get; set; }
        public string publishDate { get; set; }
        public string createDate { get; set; }
    }
