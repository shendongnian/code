    public class Message<TIn, TOut> : IMessage,
        where TIn : class, IMessagePart
        where TOut : class, IMessagePart
    {
        public TIn input { get; set; }
        public TOut output { get; set; } 
        public Message(TIn inpart, TOut outpart) {
            this.input = inpart;
            this.output = outpart;
        }
    }
