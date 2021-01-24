    public class CookieAccessor: ICookieAccessor
    {
             private readonly IHttpContextAccessor _httpContext;
    
             public class CookieAccessor(IHttpContextAccessor httpContext){
                    _httpContext = httpContext;
             }
    
             public string GetCookieValueByName(string name){
                    if (_httpContext.HttpContext.Request.Cookies.TryGetValue(name, 
                                                                  out var value))
                    {
                           return value;
                     }
                     return null;
             }
    }
