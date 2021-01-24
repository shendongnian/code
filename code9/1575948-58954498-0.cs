        protected override void OnStart(string[] args)
                {
                    _factory = new ConnectionFactory()
                    {
                        HostName = "Host",
                        UserName = "username",
                        Password = "password"
                    };
                    _connection = _factory.CreateConnection();
                    _channel = _connection.CreateModel();
    
                    _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false,autoDelete: false, arguments: null);
        
                    _consumer = new EventingBasicConsumer(_channel);
        
                    _consumer.Received += (s, ev) =>
                    {
                        //Handle messages here.
                    };
        
                    _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: _consumer);
                }
