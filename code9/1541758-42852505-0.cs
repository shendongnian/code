    public class WebRole : RoleEntryPoint
    {
    
        public override bool OnStart()
        {
            return base.OnStart();
        }
    
        public override void Run()
        {
            //Replace the code with your logic
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("my connection string");
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();        
            CloudQueue queue = queueClient.GetQueueReference("mymessage");
        
            while (true)
            {
                CloudQueueMessage message = new CloudQueueMessage("worker run at " + DateTime.UtcNow.ToString());
    
                queue.AddMessage(message);
        
                System.Threading.Thread.Sleep(60000);
    
            }
        }
    }
