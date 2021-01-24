        public void Listen(QueueType queue, Action<BrokeredMessage> callback)
        {
                OnMessageOptions options = new OnMessageOptions
                {   
                    MaxConcurrentCalls = maxConcurrent,
                    AutoComplete = false
                };
    
                switch (queue)
                {
                    case QueueType.Inbound:
                        inboundClient.OnMessageAsync(async message =>
                        {
                            bool shouldAbandon = false;
                            try
                            {
                                callback(message);
    
                                // complete if successful processing
                                await message.CompleteAsync();
                            }
                            catch (Exception ex)
                            {
                                shouldAbandon = true;
                                Debug.WriteLine(ex);
                            }
    
                            if (shouldAbandon)
                            {
                                await m.AbandonAsync();
                            }
                        }, options);
                        break;
                    ...
                }
        }
 
