        public async Task<T> Recieve<T>(string routingKey)
        {
            var tcs = new TaskCompletionSource<T>();
            try
            {
                _channel.QueueDeclare(queue: routingKey,
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);
                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    var recievedMsg = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(message);
                    // Tries to set the result.  Will fail if the task has been cancelled
                    tcs.TrySetResult(recievedMsg);
                };
                _channel.BasicConsume(queue: routingKey,
                                        noAck: true,
                                        consumer: consumer);
                return await tcs.Task;
            }
            catch (Exception ex)
            {
                // Tries to set the exception.  Will fail if the task has been cancelled
                tcs.TrySetException(ex);
            }
            return await tcs.Task;
        }
