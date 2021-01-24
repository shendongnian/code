            var context = new LookupContext(environment);
            var factory = context.Lookup(config.ConnectionFactory) as ConnectionFactory;
            try
            {
                connectionCorp = factory.CreateConnection();
            }
            catch {
                var connectionFactory = new ConnectionFactory(factory.Url, "Receiver", environment);
                connectionCorp = connectionFactory.CreateConnection();
            }
            connectionCorp.Start();
            sessionCorp = connectionCorp.CreateSession(false, SessionMode.ClientAcknowledge);
            var queue = context.Lookup(config.Name) as Destination;
            if(queue is TIBCO.EMS.Topic)
            {
                var selector = string.Format("To='{0}' and From='{1}'", config.ToAddress, config.FromAddress);
                msgConsumer = sessionCorp.CreateConsumer(queue, selector,false);
                msgConsumer.MessageHandler += (sender, args) => {
                    action(args);
                };
            }
            else
            {
                msgConsumer = sessionCorp.CreateConsumer(queue);
                msgConsumer.MessageHandler += (sender, args) => {
                    action(args);
                };
            }
