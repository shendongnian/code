    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
    
            return Task.CompletedTask;
        }
    
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
        
            var card = CreateHeroCard();
            Attachment attachment = card.ToAttachment();
            var message = context.MakeMessage();
            message.Attachments.Add(attachment);
    
            await context.PostAsync(message);
    
            context.Wait(MessageReceivedAsync);
        }
    
        private HeroCard CreateHeroCard()
        {
            List<CardImage> cardImages = new List<CardImage>();
            cardImages.Add(new CardImage("your chart image url goes here"));
            var card = new HeroCard()
            {
                Title = "Months with Numbers Bar Chart",
                Subtitle = "Using a Chart as Image service...",
                Text = "Build and connect intelligent bots that have charts rendered as images.",
                Images = cardImages
            };
    
            return card;
        }
    }
 
