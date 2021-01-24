            var resumptionCookie = ResumptionCookie.GZipDeserialize(state);
            var message = cookie.GetMessage();
            ConnectorClient client = new ConnectorClient(new Uri(message.ServiceUrl));
            var conversation = await 
            client.Conversations.CreateDirectConversationAsync(message.Recipient, message.From);
            message.Conversation.Id = conversation.Id;
            var newMessage = message.CreateReply();
            newMessage.Text = content;
            await client.Conversations.SendToConversationAsync(newMessage);
