    public static async Task EndConversation(this IBotToUser botToUser, string code = EndOfConversationCodes.CompletedSuccessfully, CancellationToken cancellationToken = default(CancellationToken))
    {
    	var message = botToUser.MakeMessage();
    	message.Type = ActivityTypes.EndOfConversation;
    	message.AsEndOfConversationActivity().Code = code;
    
    	await botToUser.PostAsync(message, cancellationToken);
    }
