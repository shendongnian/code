    public interface IMessageData {}
    public interface IMessageSender
    {
        Task<object> BuildType();
        Task SendMessage(object message);
    }
    public interface IMessageSender<T> : IMessageSender where T : class, IMessageData, new()
    {
        Task<T> BuildType();
        Task SendMessage(T message);
    }
