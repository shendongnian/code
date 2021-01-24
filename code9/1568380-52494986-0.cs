    public class RabbitListener
    {
        ConnectionFactory factory { get; set; }
        IConnection connection { get; set; }
        IModel channel { get; set; }
        public void Register()
        {
            channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                int m = 0;
            };
            channel.BasicConsume(queue: "hello", autoAck: true, consumer: consumer);
        }
        public void Deregister()
        {
            this.connection.Close();
        }
        public RabbitListener()
        {
            this.factory = new ConnectionFactory() { HostName = "localhost" };
            this.connection = factory.CreateConnection();
            this.channel = connection.CreateModel();
            
        }
    }
