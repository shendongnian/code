     using (var connection = factory.CreateConnection())
            {
                
                using (var channel = connection.CreateModel())
                {
                    var queueDeclareOK = channel.QueueDeclarePassive(QueueName);
                    var consumerCount = queueDeclareOK.ConsumerCount;
                }
            }
