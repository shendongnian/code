    // Message processors
    [MessageProcessor(typeof(MessageA))]
    class MessageAProcessor : MessageProcessor
    {
        public override void ProcessMessage(Message message)
        {
            Console.WriteLine("Processing A message...");
        }
    }
    [MessageProcessor(typeof(MessageB))]
    class MessageBProcessor : MessageProcessor
    {
        public override void ProcessMessage(Message message)
        {
            Console.WriteLine("Processing B message...");
        }
    }
