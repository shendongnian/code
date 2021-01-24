    public class Import 
    {
        private static ILog Log
        {
            get
            {
                if (LogManager.GetCurrentLoggers().Length == 0)
                {
                    // load logger config with XmlConfigurator
                    log4net.Config.XmlConfigurator.Configure();
                }
                return LogManager.GetLogger(typeof(Import));
            }
        }
