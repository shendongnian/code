    using System;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;
    
    namespace Bus {
    
        public abstract class BaseMessageListener {
            private static IModel _channel;
            private static IConnection _connection;
    
            public abstract void ConsumerOnReceived(object sender, BasicDeliverEventArgs ea);
    
            public void Start(string hostName, int port, string queueName) {
                var factory = new ConnectionFactory() { HostName = hostName, Port = port };
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false);
                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += ConsumerOnReceived;
                _channel.BasicConsume(queue: queueName, noAck: true, consumer: consumer);//This will start another thread!
            }
    
            public void Stop() {
                _channel.Close(200, "Goodbye");
                _connection.Close();
            }
        }
    }
    
    namespace StackOverfFLow.RabbitMQSolution {
    
        using Bus;
    
        public class MessageListener : BaseMessageListener {
    
            public override void ConsumerOnReceived(object sender, BasicDeliverEventArgs ea) {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            }
        }
    
        internal class Program {
    
            private static void Main(string[] args) {
                var listener = new MessageListener();
                listener.Start("localhost", 5672, "MakePayment");
                Console.WriteLine("Core Service Started!");
                Console.ReadKey();
                listener.Stop();
            }
        }
    }
