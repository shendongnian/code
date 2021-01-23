    public interface IMessageHandler
    {
        IMessage Transform(IMessage message);
        int Code {get; set;}
    }
    
    public abstract class MessageHandlerBase : IMessageHandler
    {
        public MessageHandlerBase(int code) 
        {
            Code = code;
        }
    
        public abstract IMessage Transform(IMessage message);
        public int Code {get; set;}
    }
