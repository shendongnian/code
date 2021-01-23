    public class DefaultMessageHandler
    {
    
        IMessage Transform(IMessage message)
        {
            return message;
        }
    }
    
    public class BehaviorXMessageHandler
    {
    
        IMessage Transform(IMessage message)
        {
            message.SomeProperty = "hello world";
            return message;
        }
    }
