    public class MappingMessageHandlerFactory : IMessageHandlerFactory
    {
        public MappingMessageHandlerFactory(Dictionary<int,IMessageHandler> mapping, IMessageHandler defaultBehavior)
        {
            Mapping = mapping;
            DefaultBehavior = defaultBehavior;
        }
    
        public IMessageHandler GetHandler(int messageCode)
        {
            IMessageHandler output = DefaultBehavior;
            Mapping.TryGetValue(messageCode, out output);
    
            return output;
        }
    
        public Dictionary<int,IMessageHandler> Mapping {get; set;}
        public IMessageHandler DefaultBehavior {get;set;}
    }
