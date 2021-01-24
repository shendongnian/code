     static void Main()
            {
                var config = new JobHostConfiguration();
    
                if (config.IsDevelopment)
                {
                    config.UseDevelopmentSettings();
                }
    
                var sbConfig = new ServiceBusConfiguration
                {
                    MessageOptions = new OnMessageOptions
                    {
                        AutoComplete = false,
                        MaxConcurrentCalls = 1
                    }
                };
                sbConfig.MessagingProvider = new CustomMessagingProvider(sbConfig);
                config.UseServiceBus(sbConfig);
                var host = new JobHost(config);
        
                // The following code ensures that the WebJob will be running continuously
                host.RunAndBlock();
            }
