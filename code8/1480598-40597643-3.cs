     ManualResetEvent CompletedResetEvent = new ManualResetEvent(false);
        SubscriptionClient Client;
        public void ReceiveMessagesFromSubscription(string topicName, string subscriptionFilter, string connectionString)
        {
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
                        Trace.WriteLine("Got the message with ID {0}", message.MessageId);
                        message.Complete(); // Remove message from subscription.
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine("Exception occurred receiving a message: {0}" + ex.ToString());
                        message.Abandon(); // Failed. Leave the message for retry or max deliveries is exceeded and it dead letters.
                    }
                }, options);
                CompletedResetEvent.WaitOne();
            });
        }
        /// <summary>
        /// Added in rudimentary exception handling .
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="ex">The <see cref="ExceptionReceivedEventArgs"/> instance containing the event data.</param>
        private void LogErrors(object sender, ExceptionReceivedEventArgs ex)
        {
            Trace.WriteLine("Exception occurred in OnMessage: {0}" + ex.ToString());
        }
        /// <summary>
        /// Call this to stop the messages arriving from subscription.
        /// </summary>
        public void StopMessagesFromSubscription()
        {
            Client.Close(); // Close the message pump down gracefully
            CompletedResetEvent.Set(); // Let the execution of the listener complete and terminate gracefully 
        }
