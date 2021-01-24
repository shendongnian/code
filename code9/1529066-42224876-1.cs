    ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
    #region HeroCard
    Activity replyToConversation = activity.CreateReply("Should go to conversation, with a hero card");
    replyToConversation.Recipient = activity.From;
    replyToConversation.Type = "message";
    replyToConversation.Attachments = new List<Attachment>();
    // First Change
    // Card #One
    List<CardImage> cardImages1 = new List<CardImage>();
    cardImages1.Add(new CardImage(url: "https://upload.wikimedia.org/wikipedia/en/a/a6/Bender_Rodriguez.png"));
    List<CardAction> cardButtons1 = new List<CardAction>();
    CardAction plButton1 = new CardAction()
    {
        Value = "https://en.wikipedia.org/wiki/Pig_Latin",
        Type = "openUrl",
        Title = "WikiPedia Page"
    };
    cardButtons1.Add(plButton1);
    HeroCard plCard1 = new HeroCard()
    {
        Title = "I'm a hero card",
        Subtitle = "Pig Latin Wikipedia Page",
        Images = cardImages1,
        Buttons = cardButtons1
    };
    Attachment plAttachment1 = plCard1.ToAttachment();
    replyToConversation.Attachments.Add(plAttachment1);
    // Card #Two
    List<CardImage> cardImages2 = new List<CardImage>();
    cardImages2.Add(new CardImage(url: "https://upload.wikimedia.org/wikipedia/en/archive/a/a9/20151112035044!Banyan_Tree_(_Shiv_Bajrang_Dham_Kishunpur).jpeg"));
    List<CardAction> cardButtons2 = new List<CardAction>();
    CardAction plButton2 = new CardAction()
    {
        Value = "https://en.wikipedia.org/wiki/Pig_Latin",
        Type = "openUrl",
        Title = "WikiPedia Page"
    };
    cardButtons2.Add(plButton2);
    HeroCard plCard2 = new HeroCard()
    {
        Title = "I'm a hero card",
        Subtitle = "Pig Latin Wikipedia Page",
        Images = cardImages2,
        Buttons = cardButtons2
    };
    Attachment plAttachment2 = plCard2.ToAttachment();
    replyToConversation.Attachments.Add(plAttachment2);
    // Second Change
    replyToConversation.AttachmentLayout = "carousel";
    var reply = await connector.Conversations.SendToConversationAsync(replyToConversation);
    #endregion
