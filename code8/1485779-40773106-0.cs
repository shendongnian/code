    using DasMulli.Win32.ServiceUtils;
    
    class Program
    {
        public static void Main(string[] args)
        {
            var myService = new MyService();
            var serviceHost = new Win32ServiceHost(myService);
            serviceHost.Run();
        }
    }
    
    class MyService : IWin32Service
    {
        public string ServiceName => "Test Service";
    
        public void Start(string[] startupArguments, ServiceStoppedCallback serviceStoppedCallback)
        {
            // Start coolness and return
        }
    
        public void Stop()
        {
            // shut it down again
        }
    }
