    class MyClass
    {
        private static Logger Logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            Console.Write("lol");
            Logger.Debug("Debug test...");
            Logger.Error("Debug test...");
            Logger.Fatal("Debug test...");
            Logger.Info("Debug test...");
            Logger.Trace("Debug test...");
            Logger.Warn("Debug test...");
        }
    }
