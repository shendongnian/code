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
