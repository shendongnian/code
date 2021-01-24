     public partial class AlertEngineService
        {
            public void Run(string[] args)
            {
    
                OnStart(args);
                Console.WriteLine("Press any key to stop program alert engine service");
                Console.Read();
                OnStop();
            }
        }
    }
