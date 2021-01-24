    static void Main()
    {
         XmlConfigurator.Configure();
         SetupLog4Net();
    }
    private static void SetupLog4Net()
    {
        Hierarchy hierarchy = LogManager.GetRepository() as Hierarchy;
        if(hierarchy != null && hierarchy.Configured)
        {
            foreach(IAppender appender in hierarchy.GetAppenders())
            {
               if(appender is AdoNetAppender)
               {
                   var adoNetAppender = (AdoNetAppender)appender;
                   adoNetAppender.ConnectionString = dbContext.Database.Connection.ConnectionString;
                   adoNetAppender.ActivateOptions();
               }
            }
        }
    }
