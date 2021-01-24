    public class MessageSender
    {
        private const string ServiceBusConnectionString = "Endpoint=sb://bialecki.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=[privateKey]";
        public async Task Send()
        {
            try
            {
                var productRating = new ProductRatingUpdateMessage { ProductId = 123, RatingSum = 23 };
                var message = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(productRating)));
                var topicClient = new TopicClient(ServiceBusConnectionString, "productRatingUpdates");
                await topicClient.SendAsync(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
