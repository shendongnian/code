    [Serializable]
    public class RaiseTicket: IDialog<object>
    {
    
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(PickExactCategory);
            return Task.CompletedTask;
        }
    
        public async Task PickExactCategory(IDialogContext context, IAwaitable<object> result)
        {
            var message = context.MakeMessage();
            message.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            message.Attachments = GetCardsAttachments(categoryList);
            await context.PostAsync(message);
            context.Wait(OnCardSelection);
        }
    
        public async Task OnCardSelection(IDialogContext context, IAwaitable<object> result)
        {
            var answer = await result as IMessageActivity;
            context.Done(new object());
        }
    
        private IList<Attachment> GetCardsAttachments(List<Categorylist> categoryList)
        {
            List<Attachment> lstAttachment = new List<Attachment>();
            foreach (Categorylist item in categoryList)
            {
                lstAttachment.Add(GetHeroCard(
                item.Title, item.SubTitle, item.Text,
                new CardAction(ActionTypes.ImBack, "Select", value: item.Tier3)));
            }
            return lstAttachment;
        }
    
        private static Attachment GetHeroCard(string title, string subtitle, string text, CardAction cardAction)
        {
            var heroCard = new HeroCard
            {
                Title = title,
                Subtitle = subtitle,
                Text = text,
                Buttons = new List<CardAction>() { cardAction },
            };
            return heroCard.ToAttachment();
        }
    }
