       private static void Setup2(ILog infoLog, ILog elog)
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
            hierarchy.Root.RemoveAllAppenders();
            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date THREAD [%thread] %logger: %message%newline"; //%-5level
            patternLayout.ActivateOptions();
            RollingFileAppender infoRoller = new RollingFileAppender();
            infoRoller.AppendToFile = true;
            infoRoller.File = @"logs\";
            infoRoller.RollingStyle = RollingFileAppender.RollingMode.Date;
            infoRoller.MaxSizeRollBackups = 3;
            infoRoller.Layout = patternLayout;
            infoRoller.DatePattern = @"IN\FO\_yyyy-MM-dd.\lo\g";
            infoRoller.StaticLogFileName = false;
            infoRoller.ActivateOptions();
            //   hierarchy.Root.AddAppender(infoRoller); //Not appended to the root logger anymore
            //ADDED CODE
            RollingFileAppender errorRoller = new RollingFileAppender();
            errorRoller.AppendToFile = true;
            errorRoller.File = @"logs\";
            errorRoller.RollingStyle = RollingFileAppender.RollingMode.Date;
            errorRoller.MaxSizeRollBackups = 3;
            errorRoller.Layout = patternLayout;
            errorRoller.DatePattern = @"ERROR_yyyy-MM-dd.\lo\g";
            errorRoller.StaticLogFileName = false;
            errorRoller.ActivateOptions();
            //   hierarchy.Root.AddAppender(errorRoller); //Not appended to the root logger anymore
            MemoryAppender memory = new MemoryAppender();
            memory.ActivateOptions();
            hierarchy.Root.AddAppender(memory);
            hierarchy.Root.Level = Level.Debug;
            hierarchy.Configured = true;
            ILog log = infoLog;
            Logger logger = (Logger)log.Logger;
            logger.AddAppender(errorRoller);
            log = elog;
            logger = (Logger)log.Logger;
            logger.AddAppender(infoRoller);
        }
