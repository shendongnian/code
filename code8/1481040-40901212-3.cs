    public class MessageListener
    {
        private readonly RabbitOptions opts;
        private readonly MessageHandlerFactory handlerFactory;
        private IConnection _connection;
        private IModel _channel;
        public MessageListener(IOptions<RabbitOptions> opts, MessageHandlerFactory handlerFactory)
        {
            this.opts = opts.Value;
            this.handlerFactory = handlerFactory;
        }
        public void Start()
        {
            var factory = new ConnectionFactory
            {
                HostName = opts.HostName,
                Port = opts.Port,
                UserName = opts.UserName,
                Password = opts.Password,
                VirtualHost = "/",
                AutomaticRecoveryEnabled = true,
                NetworkRecoveryInterval = TimeSpan.FromSeconds(15)
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "myExchange", type: "direct", durable: true);
            var queueName = "myQueue";
            QueueDeclareOk ok = _channel.QueueDeclare(queueName, true, false, false, null);
            _channel.QueueBind(queue: queueName, exchange: "myExchange", routingKey: "myRoutingKey");
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += ConsumerOnReceived;
            _channel.BasicConsume(queue: queueName, noAck: false, consumer: consumer);
        }
        public void Stop()
        {
            _channel.Close(200, "Goodbye");
            _connection.Close();
        }
        private void ConsumerOnReceived(object sender, BasicDeliverEventArgs ea)
        {
            // get the details from the event
            var body = ea.Body;
            var message = Encoding.UTF8.GetString(body);
            var messageType = "endpoint";  // hardcoding the message type while we dev...
            //var messageType = Encoding.UTF8.GetString(ea.BasicProperties.Headers["message-type"] as byte[]);
            // instantiate the appropriate handler based on the message type
            IMessageProcessor processor = handlerFactory.Create(messageType);
            processor.Process(message);
            // Ack the event on the queue
            IBasicConsumer consumer = (IBasicConsumer)sender;
            consumer.Model.BasicAck(ea.DeliveryTag, false);
        }
    }
