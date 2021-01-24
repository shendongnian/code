    public class Article
    {
    
        [Key, Column(Order = 0)]
        public int ArticleID { get; set; }
    
        [Key, Column(Order = 1)]
        public int ArticlePageNo { get; set; }
    
        public string ArticleTitle { get; set; }
    
        public string ArticleBody { get; set; }
    
        public int? ParentArticleID { get; set; }
        public int? ParentArticlePageNo { get; set; }
    
        [ForeignKey("ParentArticleID,ParentArticlePageNo")]
        public virtual Article ArticleParent { get; set; }
    
        public virtual ICollection<Article> Articles { get; set; }
    
    }
