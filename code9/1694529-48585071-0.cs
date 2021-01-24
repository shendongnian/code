    internal class Program
    {
        private const string WorkerExchange = "work.exchange";
        private const string RetryExchange = "retry.exchange";
        public const string WorkerQueue = "work.queue";
        private const string RetryQueue = "retry.queue";
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(WorkerExchange, "direct");
                    channel.QueueDeclare
                    (
                        WorkerQueue, true, false, false,
                        new Dictionary<string, object>
                        {
                            {"x-dead-letter-exchange", RetryExchange},
                            {"x-dead-letter-routing-key", RetryQueue}
                        }
                    );
                    channel.QueueBind(WorkerQueue, WorkerExchange, WorkerQueue, null);
                    channel.ExchangeDeclare(RetryExchange, "direct");
                    channel.QueueDeclare
                    (
                        RetryQueue, true, false, false,
                        new Dictionary<string, object>
                        {
                            {"x-dead-letter-exchange", WorkerExchange},
                            {"x-dead-letter-routing-key", WorkerQueue},
                            {"x-message-ttl", 30000},
                        }
                    );
                    channel.QueueBind(RetryQueue, RetryExchange, RetryQueue, null);
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Received {0}", message);
                        Thread.Sleep(1000);
                        Console.WriteLine("Rejected message");
                        channel.BasicNack(ea.DeliveryTag, false, false);
                    };
                    channel.BasicConsume(WorkerQueue, false, consumer);
                    
                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }
