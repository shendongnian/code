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
            var messageProcessorAttribute = messageType.GetCustomAttribute<MessageProcessorAttribute>();
            return messageProcessorAttribute != null ? (IMessageProcessor)Activator.CreateInstance(messageProcessorAttribute.MessageType) : null;
        }
    }
