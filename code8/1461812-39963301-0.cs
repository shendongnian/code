    public class SessionValueProvider: IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return HttpContext.Current.Session[prefix] != null;
        }
     
        public ValueProviderResult GetValue(string key)
        {
            if(HttpContext.Current.Session[key] == null)
                return null;
                 
            return new ValueProviderResult(HttpContext.Current.Session[key],
                HttpContext.Current.Session[key].ToString(), CultureInfo.CurrentCulture);
        }
    }
    public class UserModel
    {
        public string AccountNo { get; set; }
        ...
    }
    public ViewResult SomeAction(UserModel userModel, ...)
    {
        ...
    }
