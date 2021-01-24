    public interface IHandler
    {
        void Handle(IMessage message);
        int RequiredMessageType { get; }
    }
