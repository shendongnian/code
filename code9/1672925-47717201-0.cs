    {
    using System.ServiceProcess;
    using...
    
    namespace myServicenamespace
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            static void Main(string[] args)
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] { 
    				new myService() 
    			};
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
