    using ImageResizer;
    using ImageResizer.Plugins.Basic;
    public static void Run(..., TraceWriter log)
    {
        RemoveSizeLimiter(log);
        ...
    }
    private static void RemoveSizeLimiter(TraceWriter log)
    {
        var config = ImageResizer.Configuration.Config.Current;
        var sizeLimiter = config.Plugins.Get<SizeLimiting>();
        log.Info("SizeLimiter installed: " + (sizeLimiter != null).ToString());
        if (sizeLimiter != null)
        {
            log.Info("Uninstalling SizeLimiter");
            sizeLimiter.Uninstall(config);
        }
    }
