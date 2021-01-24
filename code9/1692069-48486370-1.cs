    public abstract class MessageSenderBase<T> : IMessageSender<T> where T : class, IMessageData, new()
    {
        public MessageSenderBase() {
        }
        Task<object> IMessageSender.BuildType() {
            T result = await BuildType();
            return result;
        }
        Task IMessageSender.SendMessage(object message) {
            return SendMessage((T)message);
        }
        public abstract Task<T> BuildType();
        public async Task SendMessage(T message) {
            …
        }
    }
