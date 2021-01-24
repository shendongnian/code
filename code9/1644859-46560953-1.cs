    public static void Run([TimerTrigger("*/20 * * * * *")]TimerInfo myTimer, TraceWriter log)
    {
        log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
        var connString=ConfigurationManager.AppSettings["sqldb-connectionstring"];
        using (var dbContext = new ApplicationDbContext(connString))
        {
            var ybEvents = dbContext.YogaSpaceEvent.FirstOrDefault();
            log.Info("event id = " + ybEvents?.YogaSpaceEventId);
        }
    }
