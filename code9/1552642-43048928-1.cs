    using System;
    
    [assembly: log4net.Config.XmlConfigurator(Watch = true)]
    
    namespace Log4NetConsoleApplication
    {
        class Program
        {
           
            static void Main(string[] args)
            {
                log4net.GlobalContext.Properties["LogFileName"] = "log";    
    
                log4net.ILog log = LogHelper.GetLogger();
    
                Console.WriteLine("hello world");
    
                log.Error("This is my error message");
    
                Console.ReadLine();
            }
        }
    }
