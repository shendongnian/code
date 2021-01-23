    case ActivityTypes.ConversationUpdate:
    IConversationUpdateActivity update = activity;
    var client = new ConnectorClient(new Uri(activity.ServiceUrl), new MicrosoftAppCredentials());
    if (update.MembersAdded != null && update.MembersAdded.Any())
    {
        foreach (var newMember in update.MembersAdded)
        {
            if (newMember.Id == activity.Recipient.Id)
            {
                var reply = activity.CreateReply();
                reply.Text = $"Welcome {newMember.Name}!";
                await client.Conversations.ReplyToActivityAsync(reply);
            }
        }
    }
    break;
