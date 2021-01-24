    public class Source
    { 
      public string id { get; set; } 
      public string name{get;set;}
    }
    public class Article
    {
    public Source source { get; set; }
    public string author { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string url { get; set; }
    public string urlToImage { get; set; }
    public DateTime publishedAt { get; set; }
    }
    public class RootObject
    {
    public string status { get; set; }
    public List<Article> articles { get; set; }
    }
