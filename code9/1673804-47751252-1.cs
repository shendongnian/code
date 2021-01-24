    public class Article
    {
        // object unique ID
        public int Id { get; set; }
        public string Title { get; set; }
        
        // parent Id used as foreign key
        public int? ParentArticleId { get; set; }
        // navigational property for parent
        public virtual Article ParentArticle { get; set; }
        // navigational property for children
        public virtual ICollection<Article> Articles { get; set; }
        // navigational property for article pages
        public virtual ICollection<ArticlePage> Pages { get; set; }
    }
    public class ArticlePage 
    {
        // object unique ID
        public int Id { get; set; }
        public string PageBody { get; set; }
        
        // parent Id used as foreign key
        public int ArticleId { get; set; }
        // navigational property for parent article
        public virtual Article { get; set; }
    }
