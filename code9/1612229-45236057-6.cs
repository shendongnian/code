    public class YourService
    {
        private IHostingEnvironment _env;
    
        public YourService(IHostingEnvironment env)
        {
            _env = env;
        }
        public Article CreateArticle()
        {
            return new Article(_env);
        }
    }
    
    public class AppTweet
    {
      public AppTweet(ITweet tweet, ICollection<string> keyWords, IHostingEnvironment hostingEnvironment)
      {
         // read file here for example
      }
    }
    
    public class Article()
    {
      public Article(IHostingEnvironment hostingEnvironment)
      {
        var appTweet = new AppTweet(new Tweet(), new List<string>, hostingEnvironment); 
      }
    }
