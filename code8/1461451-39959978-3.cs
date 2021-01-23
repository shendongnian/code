        class Program
    {
       
        private Logger ErrorLogger = NLog.LogManager.GetLogger("ErrorLog");
    
        static void Main(string[] args)
        {
            ErrorLogger.Error("test");
        }
    }
