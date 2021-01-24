    public static class Utility
        {
            private static ILog log = LogManager.GetLogger("CommonLogger");
            public static void LogMessage(string message)
            {
                Task.Factory.StartNew(() => log.Info(message));
            }
    }
