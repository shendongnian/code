    class Program
    {
        static string eventHubName = "{your-EventHub-name}";
        static string connectionString = "{RootManageSharedAccessKey-connection-string}";
        static void Main(string[] args)
        {
            JobHostConfiguration config = new JobHostConfiguration();
            config.Tracing.ConsoleLevel = System.Diagnostics.TraceLevel.Error;
            var eventHubConfig = new EventHubConfiguration();
            eventHubConfig.AddReceiver(eventHubName, connectionString);
            config.UseEventHub(eventHubConfig);
            JobHost host = new JobHost(config);
            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }
            //Send test messages
            Task.Run(() => {
                SendingRandomMessages();
            });
            host.RunAndBlock();
        }
        static void SendingRandomMessages()
        {
            var eventHubClient = EventHubClient.CreateFromConnectionString(connectionString,eventHubName);
            while (true)
            {
                try
                {
                    var message = Guid.NewGuid().ToString();
                    Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, message);
                    eventHubClient.Send(new EventData(Encoding.UTF8.GetBytes(message)));
                }
                catch (Exception exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} > Exception: {1}", DateTime.Now, exception.Message);
                    Console.ResetColor();
                }
                Thread.Sleep(4000);
            }
        }
    }
