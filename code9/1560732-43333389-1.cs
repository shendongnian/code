    var channel = _connection.CreateModel();
    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (ch, ea) =>
        {
            var body = ea.Body;
            // ... process the message
            channel.BasicAck(ea.DeliveryTag, false);
        };
    String consumerTag = channel.BasicConsume(queueName, false, consumer);
