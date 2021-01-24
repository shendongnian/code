    private Activity HandleSystemMessage(Activity message)
    {
    	if (message.Type == ActivityTypes.ConversationUpdate)
    	{
    		if (message.MembersAdded.Any(o => o.Id != message.Recipient.Id))
            {
                // Your PromptChoiceDialog here        
            }
    	}
    	return message;
    }
