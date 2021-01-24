    public class NewsArticle : BlogArticlesSource
    {
      public string Description { get; set; }
      public string ImageURL { get; set; }
    }
    public class VlogArticle : BlogArticlesSource
    {
      public string Title { get; set; }
      public string TargetURL { get; set; }
    }
