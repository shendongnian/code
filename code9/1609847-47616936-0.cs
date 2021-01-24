    public class CookieValueProvider: IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return HttpContext.Current.Request.Cookies[prefix] != null;
        }
    
        public ValueProviderResult GetValue(string key)
        {
            if(HttpContext.Current.Request.Cookies[key] == null)
                return null;
    
            return new ValueProviderResult(HttpContext.Current.Request.Cookies[key],
                HttpContext.Current.Request.Cookies[key].ToString(), CultureInfo.CurrentCulture);
        }
    }
