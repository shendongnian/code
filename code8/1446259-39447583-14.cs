    // Message queue
    class MessageQueue
    {
        private readonly Queue<Message> messages;
        public MessageQueue()
        {
            messages = new Queue<Message>();
        }
        public void PostMessage(Message message)
        {
            messages.Enqueue(message);
        }
        public void ProcessMessages()
        {
            while (messages.Any())
            {
                var message = messages.Dequeue();
                var messageProcessor = GetMessageProcessorOrDefault(message);
                messageProcessor?.ProcessMessage(message);
            }
        }
        private IMessageProcessor GetMessageProcessorOrDefault(Message message)
        {
            var messageType = message.GetType();
            var messageProcessorTypes = GetMessageProcessorTypes();
            var messageProcessorType = messageProcessorTypes
                .FirstOrDefault(mpt => mpt.GetCustomAttribute<MessageProcessorAttribute>()?.MessageType == messageType);
            return messageProcessorType != null ? (IMessageProcessor)Activator.CreateInstance(messageProcessorType) : null;
        }
        private IEnumerable<Type> GetMessageProcessorTypes()
        {
            // TODO: scan assemblies to retrieve IMessageProcessor implementations
            return new[]
            {
                typeof(MessageAProcessor),
                typeof(MessageBProcessor)
            };
        }
    }
