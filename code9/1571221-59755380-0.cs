    using Microsoft.Azure.ServiceBus;
    using Newtonsoft.Json;
    using System;
    using System.Text;
    using System.Threading.Tasks;
    namespace MyApplication
    {
        class Program
        {
            private const string ServiceBusConnectionString = "Endpoint=[SERVICE-BUS-LOCATION-SEE-AZURE-PORTAL];SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=[privateKey]";
            static void Main(string[] args)
            {
                Task.Run(async () =>
                {
                    await Send(123, "Send this message to the Service Bus.");
                });
                Console.Read();
            }
            public static async Task Send(int id, string messageToSend)
            {
                try
                {
                    var messageObject = new { Id = id, Message = messageToSend };
                    var message = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(messageObject)));
                    var topicClient = new TopicClient(ServiceBusConnectionString, "name-of-your-topic");
                    await topicClient.SendAsync(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
