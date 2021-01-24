    public interface IHandle<T>
    {
        void Handle(IMessage<T> message);
    }
    public interface IMessage<T>
    {
        T Payload { get; set; }
    }
