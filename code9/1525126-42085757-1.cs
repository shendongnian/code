    public class QueueConsumer : QueueConnection, IQueueConsumer
    {
        private EventingBasicConsumer consumer;
        public QueueConsumer(IOptions<RabbitMQSettings> queueConfig)
            :base(queueConfig) {}
        
        public void ReadFromQueue(Action<string, ulong> onDequeue, Action<Exception, ulong> onError)
        {
            ReadFromQueue(onDequeue, onError, _settings.QueueName);
        }
        public void ReadFromQueue(Action<string, ulong> onDequeue, Action<Exception, ulong> onError, string queueName)
        {
            CreateModel(queueName);
            consumer = new EventingBasicConsumer(_model);
            // Receive the messages
            consumer.Received += (o, e) =>
            {
                try
                {
                    var queueMessage = Encoding.UTF8.GetString(e.Body);
                    onDequeue.Invoke(queueMessage, e.DeliveryTag);
                }
                catch (Exception ex)
                {
                    onError.Invoke(ex, e.DeliveryTag);
                }
            };
            // if the consumer shutdown reconnects to rabbitmq and begin reading from the queue again.
            consumer.Shutdown += (o, e) =>
            {
                CreateModel(queueName);
                ReadFromQueue(onDequeue, onError, queueName);
            };
            _model.BasicConsume(queueName, false, consumer);
        }
        public void AcknowledgeMessage(ulong deliveryTag)
        {
            if (!IsConnected) Connect();
            CreateModel(_settings.QueueName);
            _model.BasicAck(deliveryTag, false);
        }
        public void StopListening()
        {
            _model.BasicCancel(consumer.ConsumerTag);
        }
    }
