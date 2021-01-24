                ConnectionFactory factory = new ConnectionFactory();
                factory.HostName = "localhost";
                factory.UserName = "guest";
                factory.Password = "guest";
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueuePurge(queueName);
                    }
                    
                }
