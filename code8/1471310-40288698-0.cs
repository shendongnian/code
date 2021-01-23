    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
    
            //Add this so all controllers need Authorization
            filters.Add(new AuthorizeAttribute());
        }
    }
