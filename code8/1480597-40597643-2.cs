     ManualResetEvent completedResetEvent = new ManualResetEvent(false);
        SubscriptionClient Client;
        public void ReceiveMessagesFromSubscription(string topicName, string subscriptionFilter, string connectionString)
        {
            var newMessage = new MessageQuery();
            Task listener = Task.Factory.StartNew(() =>
            {
                // You only need to set up the below once. 
                Client = SubscriptionClient.CreateFromConnectionString(connectionString, topicName, subscriptionFilter);
                OnMessageOptions options = new OnMessageOptions();
                options.AutoComplete = false;
                options.AutoRenewTimeout = TimeSpan.FromMinutes(1);
                options.ExceptionReceived += LogErrors;
                Client.OnMessage((message) =>
                {
                    try
                    {
                        Dictionary<string, string> retrievedMessage = new Dictionary<string, string>();
                        retrievedMessage.Add("messageGuid", message.Properties["MessageGuid"].ToString());
                        retrievedMessage.Add("instanceId", message.Properties["InstanceId"].ToString());
                        retrievedMessage.Add("pId", message.Properties["ProcessId"].ToString());
                        retrievedMessage.Add("processKey", message.Properties["ProcessKey"].ToString());
                        retrievedMessage.Add("message", message.Properties["Message"].ToString());
                        newMessage.AnnounceNewMessage(retrievedMessage); // Do what you need to with your message here!
                        message.Complete(); // Remove message from subscription.
                    }
                    catch (Exception ex)
                    {
                        string exmes = ex.Message;
                        message.Abandon();
                    }
                }, options);
                completedResetEvent.WaitOne();
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
        /// <summary>
        /// Added in rudimentary exception handling .
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ExceptionReceivedEventArgs"/> instance containing the event data.</param>
        private void LogErrors(object sender, ExceptionReceivedEventArgs e)
        {
            if (e.Exception != null)
            {
                Trace.WriteLine("Error: " + e.Exception.Message);
            }
        }
        /// <summary>
        /// Call this to stop the messages arriving from subscription.
        /// </summary>
        public void StopMessagesFromSubscription()
        {
            Client.Close(); // Close the message pump down gracefully
            CompletedEvent.Set(); // Let the execution of the listener complete and terminate gracefully 
        }
