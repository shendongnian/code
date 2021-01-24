    public class ChannelProvider : IChannelProvider {    
        private readonly ConnectionDetail connectionDetail;
        private readonly QueueDetail queueDetail;
    
        public ChannelProvider(IOptions<ConnectionDetail> connectionDetail, IOptions<QueueDetail> queueDetail) {
            this.connectionDetail = connectionDetail.Value;
            this.queueDetail = queueDetail.Value;
        }    
    
        public IChannel CreateConnectionAndChannel() {
            var factory = new Factory();
            var adapter = factory.Connect(MessagingType.MQ, connectionDetail);          
            return adapter.BindQueue(queueDetail);
        }
    }
