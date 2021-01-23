    private static async Task StartHost(string eventHubName)
            {
                string eventProcessorHostName = "1";
                string storageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", ConstFile.storageAccountName, ConstFile.storageAccountKey);
                host = new EventProcessorHost(
                    eventProcessorHostName,
                    eventHubName,
                    ConstFile.ConsumerGroup,
                    ConstFile.eventHubConnectionString,
                    storageConnectionString, eventHubName.ToLowerInvariant());
    
                factory = new DemoEventProcessorFactory(eventProcessorHostName);
    
                try
                {
                    var options = new EventProcessorOptions();
                    options.ExceptionReceived += (sender, e) => { Console.WriteLine(e.Exception); };
                    await host.RegisterEventProcessorFactoryAsync(factory);
                }
                catch (Exception exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} > Exception: {1}", DateTime.Now.ToString(), exception.Message);
                    Console.ResetColor();
                }
            }
        }
    }
