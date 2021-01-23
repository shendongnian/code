    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            var useSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["useSsl"]);
            if (useSsl )
            {
                filters.Add(new RequireHttpsAttribute());
            }
        }
    }
