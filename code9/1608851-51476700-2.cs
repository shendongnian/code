    [assembly: Dependency (typeof(BaseUrl))]
     namespace yournamespace {
       public class BaseUrl_Android : IBaseUrl {
          public string Get() {
            return "file:///android_asset/";
         } 
       }
     }
