    public static void Register(HttpConfiguration config)
    {
        config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
        config.Formatters.Remove(config.Formatters.XmlFormatter);
    }
