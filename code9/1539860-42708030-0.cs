                 // create connector service
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                // get state client object
                StateClient stateClient = activity.GetStateClient();
                // retrieve user data
                BotData userData = await stateClient.BotState.GetUserDataAsync(activity.ChannelId, activity.From.Id);
                
                bool SentGreeting;
                if (activity.Text == "hello" || activity.Text == "hi")
                {
                    SentGreeting = true;
                } else
                {
                    SentGreeting = false;
                }
                userData.SetProperty<bool>("SentGreeting", SentGreeting);
                
                // save state
                await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);
                // initiate CardDialog
                await Conversation.SendAsync(activity, () => new CardDialog());
