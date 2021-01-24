    public static HttpConfiguration ReplaceExceptionHandler(this HttpConfiguration config) {
        var errorHandler = config.Services.GetExceptionHandler();
        if (!(errorHandler is WebApiExceptionHandler)) {
            var service = config.Services.GetService(typeof(WebApiExceptionHandler));
            config.Services.Replace(typeof(IExceptionHandler), service);
        }
        return config;
    }
