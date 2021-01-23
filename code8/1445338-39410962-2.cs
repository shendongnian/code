    public class Articles
    {
        public string Artname { get; set; }
    
        [ForeignKey("ArtdatabaseId")]
        public virtual ArticleDataBase Artdatabase { get; set; }
    
        // For alternative 2 you'll need this.
        public int ArtdatabaseId { get; set; }
    }
