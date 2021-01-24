     public class CustomMessagingProvider : MessagingProvider
        {
            private readonly ServiceBusConfiguration _config;
    
            public CustomMessagingProvider(ServiceBusConfiguration config)
                : base(config)
            {
                _config = config;
            }
    
            public override NamespaceManager CreateNamespaceManager(string connectionStringName = null)
            {
                // you could return your own NamespaceManager here, which would be used
                // globally
                return base.CreateNamespaceManager(connectionStringName);
            }
    
            public override MessagingFactory CreateMessagingFactory(string entityPath, string connectionStringName = null)
            {
                // you could return a customized (or new) MessagingFactory here per entity
                return base.CreateMessagingFactory(entityPath, connectionStringName);
            }
    
            public override MessageProcessor CreateMessageProcessor(string entityPath)
            {
                // demonstrates how to plug in a custom MessageProcessor
                // you could use the global MessageOptions, or use different
                // options per entity
                return new CustomMessageProcessor(_config.MessageOptions);
            }
    
            private class CustomMessageProcessor : MessageProcessor
            {
                public CustomMessageProcessor(OnMessageOptions messageOptions)
                    : base(messageOptions)
                {
                }
    
                public override Task<bool> BeginProcessingMessageAsync(BrokeredMessage message, CancellationToken cancellationToken)
                {
                    // intercept messages before the job function is invoked
                    return base.BeginProcessingMessageAsync(message, cancellationToken);
                }
    
                public override async Task CompleteProcessingMessageAsync(BrokeredMessage message, FunctionResult result, CancellationToken cancellationToken)
                {
                    if (result.Succeeded)
                    {
                        if (!MessageOptions.AutoComplete)
                        {
                            // AutoComplete is true by default, but if set to false
                            // we need to complete the message
                            cancellationToken.ThrowIfCancellationRequested();
    
                 
                            await message.CompleteAsync();
                           
                            Console.WriteLine("Begin sleep");
                            //Sleep 5 seconds
                            Thread.Sleep(5000);
                            Console.WriteLine("Sleep 5 seconds");
    
                        }
                    }
                    else
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await message.AbandonAsync();
                    }
                }
            }
        }
