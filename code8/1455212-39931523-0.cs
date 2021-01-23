        public bool publish(string message)
        {
            var appSettings = config.getAppSettings();
            string HostName = appSettings["RABBITMQ_HOSTNAME"];
            string UserName = appSettings["RABBITMQ_USERNAME"];
            string Password = appSettings["RABBITMQ_PASSWORD"];
            var factory = new ConnectionFactory()
            {
                HostName = HostName,
                UserName = UserName,
                Password = Password
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                bool successful = false;
                var responseReceivedEvent = new ManualResetEvent(false);
                string exchangeName = appSettings["RABBITMQ_EXCHANGE"];
                string routingKey = appSettings["RABBITMQ_ROUTING_KEY"];
                Dictionary<string, object> headers = new Dictionary<string, object>();
                channel.BasicAcks += (model, args) =>
                {
                    successful = true;
                    responseReceivedEvent.Set();
                };
                channel.BasicNacks += (model, args) =>
                {
                    successful = false;
                    responseReceivedEvent.Set();
                };
                channel.ConfirmSelect();
                channel.ExchangeDeclare(exchangeName, ExchangeType.Topic, true, false, null);
                var body = Encoding.UTF8.GetBytes(message);
                IBasicProperties props = channel.CreateBasicProperties();
                props.ContentType = constants.RABBITMQ_MESSAGE_CONTENT_TYPE;
                props.ContentEncoding = constants.RABBITMQ_MESSAGE_CONTENT_ENCODING;
                props.DeliveryMode = constants.RABBITMQ_MESSAGE_DELIVERY_MODE_PERSISTENT;
                props.MessageId = Guid.NewGuid().ToString();
                props.AppId = constants.APP_ID;
                props.Type = constants.RABBITMQ_MESSAGE_TYPE;
                props.Headers = (IDictionary<string,object>)headers;
                props.Headers.Add("version", constants.VERSION);
                props.Timestamp = new AmqpTimestamp();
                channel.BasicPublish(exchange: exchangeName,
                                     routingKey: routingKey,
                                     basicProperties: props,
                                     body: body);
                responseReceivedEvent.WaitOne();
                return successful;
            }
        }public bool publish(string message)
        {
            var appSettings = config.getAppSettings();
            string HostName = appSettings["RABBITMQ_HOSTNAME"];
            string UserName = appSettings["RABBITMQ_USERNAME"];
            string Password = appSettings["RABBITMQ_PASSWORD"];
            var factory = new ConnectionFactory()
            {
                HostName = HostName,
                UserName = UserName,
                Password = Password
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                bool successful = false;
                var responseReceivedEvent = new ManualResetEvent(false);
                string exchangeName = appSettings["RABBITMQ_EXCHANGE"];
                string routingKey = appSettings["RABBITMQ_ROUTING_KEY"];
                Dictionary<string, object> headers = new Dictionary<string, object>();
                channel.BasicAcks += (model, args) =>
                {
                    successful = true;
                    responseReceivedEvent.Set();
                };
                channel.BasicNacks += (model, args) =>
                {
                    successful = false;
                    responseReceivedEvent.Set();
                };
                channel.ConfirmSelect();
                channel.ExchangeDeclare(exchangeName, ExchangeType.Topic, true, false, null);
                var body = Encoding.UTF8.GetBytes(message);
                IBasicProperties props = channel.CreateBasicProperties();
                props.ContentType = constants.RABBITMQ_MESSAGE_CONTENT_TYPE;
                props.ContentEncoding = constants.RABBITMQ_MESSAGE_CONTENT_ENCODING;
                props.DeliveryMode = constants.RABBITMQ_MESSAGE_DELIVERY_MODE_PERSISTENT;
                props.MessageId = Guid.NewGuid().ToString();
                props.AppId = constants.APP_ID;
                props.Type = constants.RABBITMQ_MESSAGE_TYPE;
                props.Headers = (IDictionary<string,object>)headers;
                props.Headers.Add("version", constants.VERSION);
                props.Timestamp = new AmqpTimestamp();
                channel.BasicPublish(exchange: exchangeName,
                                     routingKey: routingKey,
                                     basicProperties: props,
                                     body: body);
                responseReceivedEvent.WaitOne();
                return successful;
            }
        }
