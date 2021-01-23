    [MessageProcessor(typeof(MessageA))]
    class MessageAProcessor : MessageProcessor<MessageA>
    {
        protected override void ProcessMessage(MessageA message)
        {
            Console.WriteLine("Processing A message...");
        }
    }
    [MessageProcessor(typeof(MessageB))]
    class MessageBProcessor : MessageProcessor<MessageB>
    {
        protected override void ProcessMessage(MessageB message)
        {
            Console.WriteLine("Processing B message...");
        }
    }
