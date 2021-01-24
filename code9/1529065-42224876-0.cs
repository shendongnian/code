    #region HeroCard
    Activity replyToConversation = activity.CreateReply("Should go to conversation, with a hero card");
    replyToConversation.Recipient = activity.From;
    replyToConversation.Type = "message";
    replyToConversation.Attachments = new List<Attachment>();
    List<CardImage> cardImages1 = new List<CardImage>();
    cardImages1.Add(new CardImage(url: "https://upload.wikimedia.org/wikipedia/en/a/a6/Bender_Rodriguez.png"));
    List<CardImage> cardImages2 = new List<CardImage>();
    cardImages2.Add(new CardImage(url: "https://upload.wikimedia.org/wikipedia/en/archive/a/a9/20151112035044!Banyan_Tree_(_Shiv_Bajrang_Dham_Kishunpur).jpeg"));
    //cardImages.Add(new CardImage(url: "https://upload.wikimedia.org/wikipedia/en/archive/a/a9/20151112035044!Banyan_Tree_(_Shiv_Bajrang_Dham_Kishunpur).jpeg"));
    List<CardAction> cardButtons = new List<CardAction>();
    CardAction plButton1 = new CardAction()
    {
        Value = "https://en.wikipedia.org/wiki/Pig_Latin",
        Type = "openUrl",
        Title = "WikiPedia Page"
    };
    CardAction plButton2 = new CardAction()
    {
        Value = "https://en.wikipedia.org/wiki/Pig_Latin",
        Type = "openUrl",
        Title = "WikiPedia Page"
    };
    cardButtons.Add(plButton1);
    cardButtons.Add(plButton2);
    HeroCard plCard1 = new HeroCard()
    {
        Title = "I'm a hero card",
        Subtitle = "Pig Latin Wikipedia Page",
        Images = cardImages1,
        Buttons = cardButtons
        //Tap = plButton1
    };
    HeroCard plCard2 = new HeroCard()
    {
        Title = "I'm a hero card",
        Subtitle = "Pig Latin Wikipedia Page",
        Images = cardImages2,
        Buttons = cardButtons
        //Tap = plButton2
    };
    Attachment plAttachment1 = plCard1.ToAttachment();
    Attachment plAttachment2 = plCard2.ToAttachment();
    replyToConversation.AttachmentLayout = "carousel";
    replyToConversation.Attachments.Add(plAttachment1);
    replyToConversation.Attachments.Add(plAttachment2);
    var reply = await connector.Conversations.SendToConversationAsync(replyToConversation);
    #endregion
