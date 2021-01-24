    public interface IHandleMessage
    {
        void Handle(BaseMessage msg);
    }
    public class HandleMessageOne:IHandleMessage
    {
        void Handle(BaseMessage msg)
        {
            var msgOne = msg as MessageOne;
            // do something with msgOne...
        }
    }
    // etc...
