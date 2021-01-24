    public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
                {
                    if (activity.Type == ActivityTypes.Message)
                    {
        
                        var message = activity as IMessageActivity;
                        using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
                        {
                            var botDataStore = scope.Resolve<IBotDataStore<BotData>>();
                            var key = new AddressKey()
                            {
                                BotId = message.Recipient.Id,
                                ChannelId = message.ChannelId,
                                UserId = message.From.Id,
                                ConversationId = message.Conversation.Id,
                                ServiceUrl = message.ServiceUrl
                            };
                            ConversationReference r = new ConversationReference();
                            var userData = await botDataStore.LoadAsync(key, BotStoreType.BotUserData, CancellationToken.None);
        
                            userData.SetProperty("key 1", "value1");
                            userData.SetProperty("key 2", "value2");
        
                            await botDataStore.SaveAsync(key, BotStoreType.BotUserData, userData, CancellationToken.None);
                            await botDataStore.FlushAsync(key, CancellationToken.None);
                        }
                        await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
                    }
        		}	
        		
        	public class AddressKey : IAddress
            {
                public string BotId { get; set; }
                public string ChannelId { get; set; }
                public string ConversationId { get; set; }
                public string ServiceUrl { get; set; }
                public string UserId { get; set; }
            }
