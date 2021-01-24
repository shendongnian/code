    public class Global : System.Web.HttpApplication
        {
               static string text;
            protected void Application_Start(object sender, EventArgs e)
            {
                 text = AppDomain.CurrentDomain.BaseDirectory + "\\logs\\logs--" + string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now) + ".log";
               
                Log.Logger = new LoggerConfiguration()
                  .MinimumLevel.Debug()
                  .WriteTo.File(text, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}", shared: true)
                  .CreateLogger();
                Log.Information("Hello, world!");
    
                int a = 10, b = 0;
                try
                {
                    Log.Debug("Dividing {A} by {B}", a, b);
             
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Something went wrong");
                }
            }
    
            protected void Application_End(object sender, EventArgs e)
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                             "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
    
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
    
     
                CloudBlobContainer container = blobClient.GetContainerReference("mycontainer");
                string text2 = text;
    
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now) + ".log");
    
                Log.CloseAndFlush();
    
    
                using (var fileStream = System.IO.File.OpenRead(text))
                {
                    blockBlob.UploadFromStream(fileStream);
                }
            }
        }
