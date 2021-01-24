    class Program
    {
        private static  log4net.ILog log = null;
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnApplicationExit);
            log= log4net.LogManager.GetLogger("test");
            log.Info("Application started");
          
            log.Info("Application is going to exit");
        }
        static void OnApplicationExit(object sender, EventArgs e)
        {
            
            Console.WriteLine("OnApplicationExit called");
            log.Info("Application exit");
            Console.WriteLine("OnApplicationExit exit");
        }
    }
