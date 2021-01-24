        static void PurgeMessagesFromSubscription()
        {
            var connectionString = "Endpoint=sb://account-name.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=access key";
            var topic = "topic-name";
            var subscription = "subscription-name";
            int batchSize = 100;
            var subscriptionClient = SubscriptionClient.CreateFromConnectionString(connectionString, topic, subscription, ReceiveMode.ReceiveAndDelete);
            do
            {
                var messages = subscriptionClient.ReceiveBatch(batchSize);
                if (messages.Count() == 0)
                {
                    break;
                }
            }
            while (true);
        }
