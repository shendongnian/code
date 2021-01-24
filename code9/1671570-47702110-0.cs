    public class DemoRootPathProvider : IRootPathProvider
    {
      public string GetRootPath()
      {
        return Directory.GetCurrentDirectory();
      }
    }
