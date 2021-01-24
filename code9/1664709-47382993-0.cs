    public class Isbn {
        public string Isbn10 { get; set; }
        public string Isbn13 { get; set; }
    }
    public class Item {
        public Isbn Isbn { get; set; }
        public string Title { get; set; }
        public IList<string> Authors { get; set; }
        public string Publisher { get; set; }
        public string ReleaseDate { get; set; }
        public int PageCount { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
    }
 
