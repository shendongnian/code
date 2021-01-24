    Activity replyToConversation = message.CreateReply("Should go to conversation");
    replyToConversation.Attachments = new List<Attachment>();
    
    List<CardAction> cardButtons = new List<CardAction>();
    
    CardAction plButton = new CardAction()
    {
        Value = $"https://<OAuthSignInURL",
        Type = "signin",
        Title = "Connect"
    };
    
    cardButtons.Add(plButton);
    
    SigninCard plCard = new SigninCard(title: "You need to authorize me", button: plButton);
    
    Attachment plAttachment = plCard.ToAttachment();
    replyToConversation.Attachments.Add(plAttachment);
    
    var reply = await connector.Conversations.SendToConversationAsync(replyToConversation);
