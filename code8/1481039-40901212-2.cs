    public class IpSetMessageProcessor : IMessageProcessor
    {
        private ILogger<IpSetMessageProcessor> logger;
        public IpSetMessageProcessor(ILogger<IpSetMessageProcessor> logger)
        {
            this.logger = logger;
        }
        public void Process(string message)
        {
            logger.LogInformation("Received message: {0}", message);
        }
    }
