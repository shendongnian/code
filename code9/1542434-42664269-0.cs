    public static class SecurityExtensions
    {
        static readonly log4net.Core.Level authLevel = new log4net.Core.Level(50000, "Auth");
    
        public static void Auth(this ILog log, string message)
        {
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, 
                authLevel, message, null);
        }
    
        public static void AuthFormat(this ILog log, string message, params object[] args)
        {
            string formattedMessage = string.Format(message, args);
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                authLevel, formattedMessage, null);
        }
    
    }
