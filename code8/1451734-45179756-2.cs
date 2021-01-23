    using LipsumGenerator.Message;
    using Messaging.Work;
    using RabbitMQ.Client;
    using System;
    using System.Configuration;
    using System.Security.Authentication;
    
    namespace Publisher
    {
        class Program
        {
            static void Main(string[] args)
            {
                var factory = new ConnectionFactory();
                factory.HostName = ConfigurationManager.AppSettings["rabbitmqHostName"];
    
                factory.AuthMechanisms = new AuthMechanismFactory[] { new ExternalMechanismFactory() };
                factory.Ssl.ServerName = ConfigurationManager.AppSettings["rabbitmqServerName"];
                factory.Ssl.CertPath = ConfigurationManager.AppSettings["certificateFilePath"];
                factory.Ssl.CertPassphrase = ConfigurationManager.AppSettings["certificatePassphrase"];
                factory.Ssl.Enabled = true;
                factory.Ssl.Version = SslProtocols.Tls12;
                factory.Port = AmqpTcpEndpoint.DefaultAmqpSslPort;
                factory.VirtualHost = "/";
    
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        Console.WriteLine(" [*] Publishing messages. To exit press CTRL+C");
                        
                        int count = 0;
                        var rand = new Random();
    
                        while (true)
                        {
                            count++;
                            WorkProcessor.EnqueueMessage(channel, "Lipsum", new LipsumGeneratorMessage(rand.Next(5)));
                            Console.WriteLine("Sent message Lipsum " + count);
                            System.Threading.Thread.Sleep(rand.Next(2000));
                        }
                    }
                }
            }
        }
    }
