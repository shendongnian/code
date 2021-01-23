    public class MessageHandlerFactory
    {
        private readonly IServiceProvider services;
        public MessageHandlerFactory(IServiceProvider services)
        {
            this.services = services;
        }
        public IMessageProcessor Create(string messageType)
        {
            switch (messageType.ToLower())
            {
                case "ipset":
                    return services.GetService<IpSetMessageProcessor>();                
                case "endpoint":
                    return services.GetService<EndpointMessageProcessor>();
                default:
                    throw new Exception("Unknown message type");
            }
        }
    }
