       Finally, the one which helped me to pass the connection information to ado.net appender 
     public static class LogConfigurator
     {
      public static void SetConnectionString(string connectionString)
      {
           Hierarchy logHierarchy = log4net.LogManager.GetRepository() as 
                                    Hierarchy;
            if (logHierarchy == null)
           {
            throw new InvalidOperationException
               ("Can't set connection string as hierarchy is null.");
        }
        var appender = logHierarchy.GetAppenders()
                                   .OfType<AdoNetAppender>()
                                   .SingleOrDefault();
        if (appender == null)
        {
            throw new InvalidOperationException
              ("Can't locate a database appender");
        }
        appender.ConnectionString = connectionString; // Using a service to get 
        //the connection information 
        appender.ActivateOptions();
   }
}
    web.config , give the same name for ado.net appender to take the connection
    <connectionStringName value="ConnectionString" /> 
      <connectionStrings>
      <add name="ConnectionString" connectionString=""
      providerName="System.Data.SqlClient" />
      </connectionStrings>
