    class Program
    {
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("AzureWebJobsDashboard", "mystorage-connectionstring");
            Environment.SetEnvironmentVariable("AzureWebJobsStorage", "mystorage-connectionstring");
            var config = new JobHostConfiguration();
    
            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }
    
            var host = new JobHost(config);
            host.RunAndBlock();
        }
    }
    
    public class Functions
    {
        public static void ProcessQueueMessage([QueueTrigger("myqueue")] string message, TextWriter log)
        {
            log.WriteLine(message);
        }
    }
