        class Program
    {
       
        private Logger ErrorLogger = NLog.LogManager.GetLogger("ErrorFile");
    
        static void Main(string[] args)
        {
            ErrorLogger.Error("test");
        }
    }
