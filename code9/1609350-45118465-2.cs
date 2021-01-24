    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LocalizationAttribute("en-US"), 0);
        }
    }
