    public static void Setup()
            {
                
    
                Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
                hierarchy.Root.RemoveAllAppenders();
    
                PatternLayout patternLayout = new PatternLayout();
    
                patternLayout.ConversionPattern = "%date THREAD [%thread] %logger: %message%newline"; //%-5level
                patternLayout.ActivateOptions();
    
    
                ILog log = LogManager.GetLogger("GENERAL-LOG");
                Logger l = (Logger)log.Logger;
    
                RollingFileAppender infoRoller = new RollingFileAppender();
    
                infoRoller.AppendToFile = true;
                infoRoller.File = @"logs\";
                infoRoller.RollingStyle = RollingFileAppender.RollingMode.Date;
                infoRoller.MaxSizeRollBackups = 3;
                infoRoller.Layout = patternLayout;
                infoRoller.DatePattern = @"IN\FO\_yyyy-MM-dd.\lo\g";
                infoRoller.StaticLogFileName = false;
                infoRoller.ActivateOptions();
    
                l.AddAppender(infoRoller);
    
    
                //ADDED CODE
    
                ILog elog = LogManager.GetLogger("ERROR-LOG");
                Logger el = (Logger)elog.Logger;
    
    
                RollingFileAppender errorRoller = new RollingFileAppender();
    
                errorRoller.AppendToFile = true;
                errorRoller.File = @"logs\";
                errorRoller.RollingStyle = RollingFileAppender.RollingMode.Date;
                errorRoller.MaxSizeRollBackups = 3;
                errorRoller.Layout = patternLayout;
                errorRoller.DatePattern = @"ERROR_yyyy-MM-dd.\lo\g";
                errorRoller.StaticLogFileName = false;
    
                errorRoller.ActivateOptions();
    
                el.AddAppender(errorRoller);
                //hierarchy.Root.AddAppender(errorRoller);
    
                MemoryAppender memory = new MemoryAppender();
    
                memory.ActivateOptions();
                hierarchy.Root.AddAppender(memory);
                hierarchy.Configured = true;
            }
