    var factory = new ConnectionFactory();
    using (var connection = factory.CreateConnection()) {
        using (var channel = connection.CreateModel()) {
            // setup signal
            using (var signal = new ManualResetEvent(false)) {
                var consumer = new EventingBasicConsumer(channel);
                byte[] messageBody = null;                        
                consumer.Received += (sender, args) => {
                    messageBody = args.Body;
                    // process your message or store for later
                    // set signal
                    signal.Set();
                };               
                // start consuming
                channel.BasicConsume("your.queue", false, consumer);
                // wait until message is received or timeout reached
                bool timeout = !signal.WaitOne(TimeSpan.FromSeconds(10));
                // cancel subscription
                channel.BasicCancel(consumer.ConsumerTag);
                if (timeout) {
                    // timeout reached - do what you need in this case
                    throw new Exception("timeout");
                }
                
                // at this point messageBody is received
            }
        }
    }
