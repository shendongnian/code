    public class Program
        {
            static void Main(string[] args)
            {
                JobHostConfiguration config = new JobHostConfiguration
                {
                    StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=storageAccountName;AccountKey=xxxxxx",
                    DashboardConnectionString = "DefaultEndpointsProtocol=https;AccountName=storageAccountName;AccountKey=xxxx;"
                };
    
                config.UseTimers();
    
                JobHost host = new JobHost(config);
                host.RunAndBlock();
            }
    
    
    
            public static void EmailsConsumer([TimerTrigger("00:30:00", RunOnStartup = true)]TimerInfo ti)
            {
                //do something
            }
        }
