    public class FilterConfig
    {
        public static void RegisterGlobalFilters(HttpFilterCollection filters)
        {
            filters.Add(new TokenValidationAttribute());
            filters.Add(new IpHostValidationAttribute());
        }
    }
