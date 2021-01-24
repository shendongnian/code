                using (channel)
                {
                    EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (o, e) =>
                    {
                        string data = Encoding.ASCII.GetString(e.Body);
                        result = MQ.utilities.Utilities.ProcessData(data, counter);
                        if (result)
                            channel.BasicAck(e.DeliveryTag, false);
                        else
                        {
                            channel.BasicNack(e.DeliveryTag, false, false);
                            //send message to another queue ...
                            IBasicProperties basicProperties = channel.CreateBasicProperties();
                            channel.BasicPublish(_exchangeName, "newqueue", basicProperties, e.Body);
                        }
                    };
                    string consumerTag = channel.BasicConsume(_publishSubscribeQueueOne, false, consumer);
                    Console.WriteLine("Listening, press ENTER to quit");
                    Console.ReadLine();
                }  
