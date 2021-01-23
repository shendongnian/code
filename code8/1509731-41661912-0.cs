    public class Communication
    {
        private readonly Logger _logger;
        private readonly IBus _bus;
        public delegate void ReceivedEventHandler(string data);
        public event ReceivedEventHandler Received;
        protected virtual void OnReceive(string data)
        {
            Received?.Invoke(data);
        }
        public Communication()
        {
            _logger = new Logger();
            _bus = RabbitHutch.CreateBus("host=localhost", reg => reg.Register<IEasyNetQLogger>(log => _logger));
            SubscribeAllQueues();
        }
        private void SubscribeAllQueues()
        {
            _bus.Receive<Message>("pipeline", message =>
            {
                OnReceive(message.Body);
            });
        }
        public void SubscribeQueue(string queueName)
        {
            _bus.Receive<Message>(queueName, message =>
            {
                OnReceive(message.Body);
            });
        }
    }
