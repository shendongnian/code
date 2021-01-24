    public class MessageController : Controller {
        private readonly IChannelProvider channelProvider;
     
        public MessageController(IChannelProvider channelProvider) {
            this.channelProvider = channelProvider;
        }
    
        [HttpGet()]
        public IActionResult Get() {
            try {
                var channel = channelProvider.CreateConnectionAndChannel();
                var message = channel.Receive();              
                var hbaseKey = new HbaseKey { Key = new Guid(message) };
                return Ok(hbaseKey);
            } catch {
                return StatusCode(500, "Exception occured while processing. Try again.");
            }
        }    
    }
