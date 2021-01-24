     public static void SetAdoNetAppenderConnectionStrings(string connectionStringKey)
     {
       var hier = (Hierarchy)LogManager.GetRepository();
       if (hier != null)
       {
         var appenders = hier.GetAppenders().OfType<ADONetAppender>();
         foreach (var appender in appenders)
         {
           appender.ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString;
           appender.ActivateOptions();
         }
       }
     }
