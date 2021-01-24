    using System.ServiceProcess;
    namespace WindowsService101
    {
    class Program
    {
        static void Main(string[] args)
        {
            using (var service = new HelloWorldService())
            {
                ServiceBase.Run(service);
            }
        }
    }
    }
    
    
    public class HelloWorldService : ServiceBase
    {
        protected override void OnStart(string[] args)
        {
           // Code Here
        }
        protected override void OnStop()
        {
            // Code Here
        }
    }
