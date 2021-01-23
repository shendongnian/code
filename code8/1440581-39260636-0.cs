    public class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        public static void Main()
        {
             if(!System.IO.Directory.Exists(@"D:\home\data\XML")) 
             {
                  System.IO.Directory.Create(@"D:\home\data\XML");
             }
             JobHostConfiguration jobConfiguration = new JobHostConfiguration();
             FilesConfiguration fileConfiguration = new FilesConfiguration();
             jobConfiguration.UseFiles(fileConfiguration);
             jobConfiguration.UseTimers();
             var host = new JobHost(jobConfiguration);
             host.RunAndBlock();
        }
