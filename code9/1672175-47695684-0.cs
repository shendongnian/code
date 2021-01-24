     public Task StartAsync(IDialogContext context)
            {
                context.Wait(MessageReceivedAsync);
    
                return Task.CompletedTask;
            }
            public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
            {
                var reply = context.MakeMessage();
    
                reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                reply.Attachments = GetCardsAttachments();
    
                await context.PostAsync(reply);
    
                context.Wait(this.MessageReceivedAsync);
            }
    
            private static IList<Attachment> GetCardsAttachments()
            {
                return new List<Attachment>()
                {
                    GetHeroCard(
                        "Add a webpage",
                        "",
                        "",
                        new CardImage(url: "https://cdn.dribbble.com/users/22691/screenshots/1958250/attachments/340010/Button_800x600.gif?sz=328"),
                        new CardAction(ActionTypes.ImBack, "Add a webpage", value: "Add a webpage")),
                    GetHeroCard(
                        "delete a webpage",
                        "",
                        "",
                        new CardImage(url: "https://cdn.dribbble.com/users/22691/screenshots/1958250/attachments/340010/Button_800x600.gif?sz=328"),
                        new CardAction(ActionTypes.ImBack, "delete a webpage", value: "delete a webpage")),
                    GetHeroCard(
                        "Display help",
                        "",
                        "",
                        new CardImage(url: "https://cdn.dribbble.com/users/22691/screenshots/1958250/attachments/340010/Button_800x600.gif?sz=328"),
                        new CardAction(ActionTypes.ImBack, "Display help", value: "Display help")),
                    GetHeroCard(
                        "etc",
                        "",
                        "",
                        new CardImage(url: "https://cdn.dribbble.com/users/22691/screenshots/1958250/attachments/340010/Button_800x600.gif?sz=328"),
                        new CardAction(ActionTypes.ImBack, "etc", value: "etc")),
    
                };
            }
    
            private static Attachment GetHeroCard(string title, string subtitle, string text, CardImage cardImage, CardAction cardAction)
            {
                var heroCard = new HeroCard
                {
                    Title = title,
                    Subtitle = subtitle,
                    Text = text,
                    Images = new List<CardImage>() { cardImage },
                    Buttons = new List<CardAction>() { cardAction },
                };
    
                return heroCard.ToAttachment();
            }
