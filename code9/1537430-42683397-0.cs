            if (activity.Type == ActivityTypes.Message)
            {
                Activity typing = activity.CreateReply(null);
                typing.ServiceUrl = activity.ServiceUrl; 
                typing.Type = ActivityTypes.Typing;
                ConnectorClient connector = new ConnectorClient(new Uri(typing.ServiceUrl));
                await connector.Conversations.SendToConversationAsync(typing);
            }
            else
            {
                HandleSystemMessage(activity);
            }
            ...
