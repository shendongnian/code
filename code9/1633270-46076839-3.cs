    public class ArticlesSource
    {
        public List<NewsArticle> GetNewsArticles() { ... }
        public List<VlogArticle> GetVlogArticles() { ... }
        public List<BlogArticle> GetBlogArticles() { ... }
    }
    public class NewsArticle : ArticlesSource
    {
      public string Description { get; set; }
      public string ImageURL { get; set; }
    }
    public class VlogArticle : ArticlesSource
    {
      public string Title { get; set; }
      public string TargetURL { get; set; }
    }
