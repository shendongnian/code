    using System;
    using System.Text;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Framing;
    
    namespace Messaging
    {
        public class MessageSender : IDisposable
        {
            private const string EXCHANGE_NAME = "MY_EXCHANGE";
    
            private readonly ConnectionFactory factory;
            private readonly IConnection connection;
            private readonly IModel channel;
    
            public MessageSender(string address, string username, string password)
            {
                factory = new ConnectionFactory {UserName = username, Password = password, HostName = address};
    
                connection = factory.CreateConnection();
                channel = connection.CreateModel();
    
                channel.ExchangeDeclare(EXCHANGE_NAME, "topic");
            }
    
            public void Send(string payload, string topic)
            {
                var prop = new BasicProperties();
                var data = Encoding.ASCII.GetBytes(payload);
                
                channel.BasicPublish(EXCHANGE_NAME, topic.ToUpper(), prop, data);
            }
    
            public void Dispose()
            {
                try
                {
                    channel.Dispose();
                    connection.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
