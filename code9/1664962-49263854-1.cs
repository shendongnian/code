    public static void Main(string[] args)
    {
        // NLog: setup the logger first to catch all errors
        var logger = NLog.Web.LogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        try
        {
            logger.Debug("init main");
            BuildWebHost(args).Run(); 
        }
        catch (Exception ex)
        {
            //NLog: catch setup errors
            logger.Error(ex, "Stopped program because of exception");
            throw;
        }
        finally
        {
            // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
            NLog.LogManager.Shutdown();
        }
    }
