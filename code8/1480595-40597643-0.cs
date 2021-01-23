            var newMessage = new MessageQuery();
            Task listener = Task.Factory.StartNew(() =>
            {
                // You only need to set up the below once. 
                SubscriptionClient Client = SubscriptionClient.CreateFromConnectionString(connectionString, topicName, subscriptionFilter);
                Dictionary<string, string> retrievedMessage = new Dictionary<string, string>();
                OnMessageOptions options = new OnMessageOptions();
                options.AutoComplete = false;
                options.AutoRenewTimeout = TimeSpan.FromMinutes(1);
                Client.OnMessage((message) =>
                {
                    try
                    {
                        retrievedMessage.Add("messageGuid", message.Properties["MessageGuid"].ToString());
                        retrievedMessage.Add("instanceId", message.Properties["InstanceId"].ToString());
                        retrievedMessage.Add("pId", message.Properties["ProcessId"].ToString());
                        retrievedMessage.Add("processKey", message.Properties["ProcessKey"].ToString());
                        retrievedMessage.Add("message", message.Properties["Message"].ToString());
                        newMessage.AnnounceNewMessage(retrievedMessage); // event ->
                        message.Complete(); // Remove message from subscription.
                    }
                    catch (Exception ex)
                    {
                        string exmes = ex.Message;
                        message.Abandon();
                    }
                }, options);
                retrievedMessage.Clear();
                // Replace this with a task cancellation so that the caller of this method
                // has a way to exit the messager processing. 
                while (true)
                {
                    Thread.Sleep(100);
                }
                // Run this in your cancellation event code to shut down the Message receiver gracefully (see previous comment)
                Client.Close();
            });
        }
    }
