    class MyLoggerClass
    {
        public static Logger Logger = LogManager.GetCurrentClassLogger();
    }
    class MyClass
    {
        static void Main(string[] args)
        {
            Console.Write("lol");
            MyLoggerClass.Logger.Debug("Debug test...");
            MyLoggerClass.Logger.Error("Debug test...");
            MyLoggerClass.Logger.Fatal("Debug test...");
            MyLoggerClass.Logger.Info("Debug test...");
            MyLoggerClass.Logger.Trace("Debug test...");
            MyLoggerClass.Logger.Warn("Debug test...");
        }
    }
