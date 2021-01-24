    private Activity HandleSystemMessage(Activity message)
    {
        if (message.Type == ActivityTypes.DeleteUserData)
        {
            // Implement user deletion here
            // If we handle user deletion, return a real message
        }
        else if (message.Type == ActivityTypes.ConversationUpdate)
        {
            // Handle conversation state changes, like members being added and removed
            // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
            // Not available in all channels
     
            // Note: Add introduction here:
            IConversationUpdateActivity update = message;
            var client = new ConnectorClient(new Uri(message.ServiceUrl), new MicrosoftAppCredentials());
            if (update.MembersAdded != null && update.MembersAdded.Any())
            {
                foreach (var newMember in update.MembersAdded)
                {
                    if (newMember.Id != message.Recipient.Id)
                    {
                        var reply = message.CreateReply();
                        reply.Text = $"Welcome {newMember.Name}!";
                        client.Conversations.ReplyToActivityAsync(reply);
                    }
                }
            }
        }
        else if (message.Type == ActivityTypes.ContactRelationUpdate)
        {
            // Handle add/remove from contact lists
            // Activity.From + Activity.Action represent what happened
        }
        else if (message.Type == ActivityTypes.Typing)
        {
            // Handle knowing tha the user is typing
        }
        else if (message.Type == ActivityTypes.Ping)
        {
        }
     
        return null;
    }
