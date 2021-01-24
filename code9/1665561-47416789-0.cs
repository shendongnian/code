    public interface IChannelFactory {
        IChannel CreateConnectionAndChannel(QueueDetail queueDetail);
    }
    
    public class ChannelFactory : IChannelFactory {
        public IChannel CreateConnectionAndChannel(QueueDetail queueDetail)
        {
            var factory = new Factory();
            var adapter = factory.Connect(MessagingType.MQ, connectionDetail);          
            return adapter.BindQueue(queueDetail);
        }
    }
    
    public class MessageController : Controller
    {       
        private readonly ConnectionDetail connectionDetail;
        private readonly QueueDetail queueDetail;
        private readonly IChannelFactory channelFactory;
    
        public MessageController(IOptions<ConnectionDetail> connectionDetail, IOptions<QueueDetail> queueDetail, IChannelFactory channelFactory)
        {
            this.connectionDetail = connectionDetail.Value;
            this.queueDetail = queueDetail.Value;
            this.channelFactory = channelFactory;
        }
    
        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
                var channel = channelFactory.CreateConnectionAndChannel(queueDetail);
                var message = channel.Receive();              
                var hbaseKey = new HbaseKey { Key = new Guid(message) };
                return Ok(hbaseKey);
            }
            catch
            {
                return StatusCode(500, "Exception occured while processing. Try again.");
            }
        }
    }
