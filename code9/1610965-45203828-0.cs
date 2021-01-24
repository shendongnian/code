    public class Functions
    {
        public static void ProcessQueueMessage([ServiceBusTrigger("inputqueue")] string message, TextWriter logger)
        {
            //deserialize the object from the message and add it to database.
        }
    }
