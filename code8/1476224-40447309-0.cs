        private static Activity ShowButtons(IDialogContext context, string strText)
    {
        // Create a reply Activity
        Activity replyToConversation = (Activity)context.MakeMessage();
        replyToConversation.Text = strText;
        replyToConversation.Recipient = replyToConversation.Recipient;
        replyToConversation.Type = "message";
        // Call the CreateButtons utility method 
        // that will create 5 buttons to put on the Here Card
        List<CardAction> cardButtons = CreateButtons();
        // Create a Hero Card and add the buttons 
        HeroCard plCard = new HeroCard()
        {
            Buttons = cardButtons
        };
        // Create an Attachment
        // set the AttachmentLayout as 'list'
        Attachment plAttachment = plCard.ToAttachment();
        replyToConversation.Attachments.Add(plAttachment);
        replyToConversation.AttachmentLayout = "list";
        // Return the reply to the calling method
        return replyToConversation;
    }
