    namespace DownloadProcessor
    {
        public class Functions
        {
            public static void ProcessQueueMessage([QueueTrigger("ringclonedownloadprocessorqueue")] string message, TextWriter log)
            {
                log.WriteLine("Processing" + message);
            }
        }
    }
