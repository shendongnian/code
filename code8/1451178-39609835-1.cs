    public interface IMessage {
        string Body { get; set; }
    }
    public abstract class MessageBase : IMessage {
        public string Body { get; set; }
    }
    public class MessageA : MessageBase {
    }
    public class MessageB : MessageBase {
    }
    public class MessageC : MessageBase {
    }
    public interface IMessageProcessor<T> where T : IMessage {
        Action<T> ProcessorAction { get; set; }
    }
    public abstract class MessageProcessorBase<T> : IMessageProcessor<T> where T : MessageBase {
        public Action<T> ProcessorAction { get; set; }
        public void ProcessMessage(IMessage message) {
            var msg = message as T;
            ProcessorAction(msg);
        }
    }
    public interface IMessageProcessor {
        void ProcessMessage(IMessage message);
    }
    public class MessageAProcessor : MessageProcessorBase<MessageA>,IMessageProcessor {
    }
    public class MessageBProcessor : MessageProcessorBase<MessageB>,IMessageProcessor {
    }
    public class MessageCProcessor : MessageProcessorBase<MessageC>,IMessageProcessor {
    }
