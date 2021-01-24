     public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> arg)
        {
           
            var replyToConversation= context.MakeMessage();
         
            replyToConversation.AttachmentLayout = "carousel";
            replyToConversation.Attachments = new List<Attachment>();
            List<CardImage> CardImages = new List<CardImage>();
            CardImages.Add(new CardImage()
            {
                Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/be/BMW-Z4_diagonal_front_at_IAA_2005.jpg/243px-BMW-Z4_diagonal_front_at_IAA_2005.jpg"
            });
    
            CardAction btnWebsite = new CardAction()
            {
                Type = "openUrl",
                Title = "Open",
                Value = "http://bmw.com"
            };
    
            HeroCard plCard = new HeroCard()
            {
                Title = $"{referenceMessage.Text}",
                Subtitle = $"Resultados de busqueda para {referenceMessage.Text}",
                Images = CardImages,
                Tap = btnWebsite
            };
    
            var attachment = plCard.ToAttachment();
            replyToConversation.Attachments.Add(attachment);
            await context.PostAsync(replyToConversation);
        }
