    foreach (var appender in log.Logger.Repository.GetAppenders())
    {
         try
         {
             ((log4net.Appender.RollingFileAppender)appender).DateTimeStrategy = movingDate;
         }
         catch {}
     }
