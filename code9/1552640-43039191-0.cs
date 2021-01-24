    static void Main(string[] args)
        {
            log4net.GlobalContext.Properties["LogFileName"] = "log.txt";
    
            log4net.ILog logger = log4net.LogManager.GetLogger("Tests");
    
            logger.Debug("Test message");
        }
