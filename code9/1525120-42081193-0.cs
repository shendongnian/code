       NameSpace = NamespaceManager.CreateFromConnectionString(ConnectionString);
       var queueInfo = NameSpace.GetQueue("happy-birthday");
        Client = QueueClient.CreateFromConnectionString(connectionString, "happy-birthday");
        if (queueInfo.MessageCount > 0)
        {
            var message = Client.Peek();
            while (message != null)
            {
                if (message.State == MessageState.Deferred)
                {
                    message = Client.Receive(message.SequenceNumber);
                }
                else
                {
                    message = Client.Receive();
                }
                
                message.Complete();
                message = Client.Peek();
            }
        }
