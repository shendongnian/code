    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // Add our MyCacheFilter globally so it runs before every request
            filters.Add(new MyCacheFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
