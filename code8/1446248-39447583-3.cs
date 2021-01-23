    interface IMessageProcessor
    {
        void ProcessMessage(Message message);
    }
    abstract class MessageProcessor<TMessage> : IMessageProcessor
        where TMessage : Message
    {
        protected abstract void ProcessMessage(TMessage message);
        public void ProcessMessage(Message message)
        {
            ProcessMessage((TMessage)message);
        }
    }
