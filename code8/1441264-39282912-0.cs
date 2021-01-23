    public class Article 
    {
        public int ArticleId { get; set; }
        public string Text { get; set; }
        // using Author model
        public Author Author { get; set; }
    }
