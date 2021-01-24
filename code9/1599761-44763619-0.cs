    public static class WebApiConfig
    {
              public static void Register(HttpConfiguration config)
              {
                     // Web API configuration and services
                        config.Filters.Add(new TestFilterAttribute());
              }
    }
