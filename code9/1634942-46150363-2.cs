    else if (message.Type == ActivityTypes.Typing)
            {
                ConnectorClient connector = new ConnectorClient(new System.Uri(message.ServiceUrl));
                connector.Conversations.ReplyToActivityAsync(message);
            }
