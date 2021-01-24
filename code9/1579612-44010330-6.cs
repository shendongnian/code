    public static void Register(HttpConfiguration config)
    {
        config.MapHttpAttributeRoutes();
        var corsAttr = new EnableCorsAttribute("*", "*", "*");
        config.EnableCors(corsAttr);
    }
