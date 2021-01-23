        else if (message.Type == ActivityTypes.ConversationUpdate)
        {
            if (message.MembersAdded.Any(o => o.Id == message.Recipient.Id))
            {
                // logic
            }
        }
