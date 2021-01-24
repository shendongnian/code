	using NLog;
	
    public class Engine
    {
        private readonly ILogger _logger;
 
        public Engine()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }
 
        public async Task SendAsync(OutboundMessageType messageType)
        {
            _logger.Trace($"Entered SendAsync() for message type '{messageType}'.");
            // other stuff here
        }
    }
