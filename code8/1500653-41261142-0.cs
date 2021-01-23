    public class GetFileController
    {
      public string GetFileContent(string url)
      {
        //Read file from disk & return content
      }
    
      public string GetCachedFileContent(string url, Cache cache)
      {
        if(!cache.ContainsUrl)
          cache[url] =  GetFileContent(url);
        return cache[url];
      }
    }
    
    public class MakeChangesController()
    {
      public string DoChanges(){}
    }
