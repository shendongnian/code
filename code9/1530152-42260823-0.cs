        public static async Task SendMessageToClient(ServerClient client, string messageText)
        {
            var connector = new ConnectorClient(new Uri(client.BotServiceUrl), new MicrosoftAppCredentials());
            var userAccount = new ChannelAccount(name: client.UserName, id: client.UserId);
            var botAccount = new ChannelAccount(name: client.BotName, id: client.BotId);
            // this worked before but not anymore
            //var conversationId = await connector.Conversations
            //       .CreateDirectConversationAsync(botAccount, userAccount).Id;
            // because client.UserId was set in a MessageController to activity.Conversation.Id we can use this
            var conversationId = client.UserId; 
            var message = Activity.CreateMessageActivity();
            message.From = botAccount;
            message.Recipient = userAccount;
            message.Conversation = new ConversationAccount(false, conversationId);
            message.Locale = "en-Us";
            if (client.ReplaceFrom != null && client.ReplaceTo != null)
            {
                messageText = messageText.Replace(client.ReplaceFrom, client.ReplaceTo);
            }
            message.Text = messageText;
            await connector.Conversations.SendToConversationAsync((Activity) message);
        }
