    public class TopicMessageProcessor
    {
        private readonly Uri _myUry;
        public TopicMessageProcessor(Uri myUry)
        {
            _myUry = myUry;
        }
        public void ProcessTopicStatusMessage([ServiceBusTrigger("%topic%", "%sub%")] BrokeredMessage message,
            TextWriter logger)
        {
            // _myUry is accessible here
        }
    }
