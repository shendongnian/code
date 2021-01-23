            var card = new HeroCard("Some Text");
            card.Buttons = new List<CardAction>()
            {
                    new CardAction()
                    {
                        Title = "button1",
                        Type=ActionTypes.ImBack,
                        Value="button1"
                    },
                    new CardAction()
                    {
                        Title = "button2",
                        Type=ActionTypes.ImBack,
                        Value="button2"
                    }
            };
            var reply = activity.CreateReply("");
            reply.Attachments = new List<Attachment>();
            reply.Attachments.Add(new Attachment()
            {
                ContentType = HeroCard.ContentType,
                Content = card
            });
            return reply;
