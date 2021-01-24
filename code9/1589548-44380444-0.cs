    public class MyQueueProcessorFactory : IQueueProcessorFactory
    {
        public  QueueProcessor Create(QueueProcessorFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (context.Queue.Name == "queue1")
            {
                context.MaxDequeueCount = 2;
            }
            else if (context.Queue.Name == "queue2")
            {
                context.MaxDequeueCount = 4;
            }
            return new QueueProcessor(context);
        }
    }
