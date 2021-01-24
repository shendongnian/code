    public interface ICookieAccessor
    {
         string GetCookieValueByName(string name);
    }
    
    public class SomeServiceThatUsesCookie()
    {
         private readonly ICookieAccessor _cookieAccessor;
         
         public SomeServiceThatUsesCookie(ICookieAccessor cookieAccessor){
               _cookieAccessor = cookieAccessor;
         }
    
         public string IWonnaCookie(string name){
               return _cookieAccessor.GetCookieValueByName(name);
         }
    }
