    private int NombreDeMessages;
            protected override async Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> item)
            {
                var message = await item;
                NombreDeMessages += 1;
                string code = EndOfConversationCodes.CompletedSuccessfully;
                CancellationToken cancellationToken = default(CancellationToken);
    
    
                if (message.Text != null && NombreDeMessages < 3)
                {
                    await base.MessageReceived(context, item);
    
                }
                else if (message.Text != null && NombreDeMessages == 3)
                {
                    AdaptiveCard card = new AdaptiveCard();
                    card.Body.Add(new TextBlock()
                    {
                        Text = "STOP FLOODING",
                        Weight = TextWeight.Bolder,
                        IsSubtle = true,
                        Wrap = true,
                        Size = TextSize.Large
                    });
    
                    card.Body.Add(new TextBlock()
                    {
                        Text = "You have reach the limit of queries",
                        IsSubtle = false,
                        Wrap = true,
                        Size = TextSize.Normal
                    });
    
                    card.Body.Add(new Image()
                    {
                        Url = "http://images.roadtrafficsigns.com/img/dp/lg/traffic-stop-sign.png",
    
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Size = ImageSize.Stretch
                    });
    
                    Attachment attachment = new Attachment()
                    {
                        ContentType = AdaptiveCard.ContentType,
                        Content = card
                    };
                    var flood = context.MakeMessage();
                    flood.Attachments.Add(attachment);
    
                    await context.PostAsync(flood);
    
                }
                else
                {
    
                    var reply = context.MakeMessage();
    
                    reply.Type = ActivityTypes.EndOfConversation;
                    reply.AsEndOfConversationActivity().Code = code;
                    
                    await context.PostAsync(reply, cancellationToken);
                    
                }
                
            }
