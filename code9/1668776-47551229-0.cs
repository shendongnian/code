    public static class ProcessQueueForIntercom
    {
        static ProcessQueueForIntercom()
        {
            MapInitializer.Activate();
        }
        [FunctionName("ProcessQueue")]
        public static void Run([QueueTrigger("messages")]string myQueueItem, TraceWriter log)
        {             
            // rest of the code
        }
    }
