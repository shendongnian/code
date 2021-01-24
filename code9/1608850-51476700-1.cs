    [assembly: Dependency(typeof(BaseUrl))]
    namespace yournamespace
    {
       public class BaseUrl: IBaseUrl
       {
          public string GetBaseUrl()
          {
            return NSBundle.MainBundle.BundlePath;
          }
       }
    }
