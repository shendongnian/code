    internal WebCache : ICache
    {
      public void Insert(string key, object value)
      {
        HttpContext.Cache.Insert(key, value);  
      }
    }
    public Controller
    {
      private service = new service(new WebCache);
    }
