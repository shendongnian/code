    public static void ProcessQueueMessage([QueueTrigger("queue3")]  string thumbnail, TextWriter log)
            {
    
                string instanceid = Environment.GetEnvironmentVariable("WEBSITE_INSTANCE_ID");
    
                log.Write( "Current instance ID : "  +  instanceid);
            }
