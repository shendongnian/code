    foreach (var appender in log.Logger.Repository.GetAppenders())
    {
        try
        {
            string file = Path.GetDirectoryName(((log4net.Appender.RollingFileAppender)appender).File);
            string filename = Path.Combine(file, fileName);
            switch (((log4net.Appender.RollingFileAppender)appender).RollingStyle)
            {
                case log4net.Appender.RollingFileAppender.RollingMode.Date:
                    ((log4net.Appender.RollingFileAppender)appender).RollingStyle = log4net.Appender.RollingFileAppender.RollingMode.Once;
                    break;
                case log4net.Appender.RollingFileAppender.RollingMode.Composite:
                    ((log4net.Appender.RollingFileAppender)appender).RollingStyle = log4net.Appender.RollingFileAppender.RollingMode.Size;
                    break;
            }
            ((log4net.Appender.FileAppender)appender).File = filename;
            ((log4net.Appender.FileAppender)appender).ActivateOptions();
        }
        catch (Exception ex) {}
    }
