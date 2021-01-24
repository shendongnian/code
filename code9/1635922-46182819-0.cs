    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Connector;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace Bot_Application13.Dialogs
    {
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
                List<Attachment> cards = new List<Attachment>();
                List<CardAction> buttons = new List<CardAction>();
                for (int i = 0; i < 10; i++)
                {
                    CardAction ca = new CardAction()
                    {
                        Title = i.ToString(),
                        Type = "postBack",
                        Text = i.ToString(),
                        Value = i.ToString()
                    };
                    buttons.Add(ca);
                }
    
                var reply = context.MakeMessage();
                GetCardsAttachments(buttons, cards);
                //reply.AttachmentLayout = AttachmentLayoutTypes.List;
                //or
                reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                reply.Attachments = cards;
    
                await context.PostAsync(reply);
    
                context.Wait(this.MessageReceivedAsync);
            }
    
            private Attachment GetHeroCard(List<CardAction> buttons)
            {
                var heroCard = new HeroCard();
                //heroCard.Title = "Title";
                heroCard.Buttons = buttons;
                return heroCard.ToAttachment();  
            }
    
            private void GetCardsAttachments(List<CardAction> buttons, List<Attachment> cards)
            {
                if (buttons.Count <= 3)
                {
                    cards.Add(GetHeroCard(buttons));
                }
                else
                {
                    var temp = new List<CardAction>();
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        if (i % 3 != 0)
                        {
                            temp.Add(buttons.ElementAt(i));
                        }
                        else
                        {
                            if (i != 0)
                            {
                                cards.Add(GetHeroCard(temp));
                            }
                            
                            temp = new List<CardAction>();
                            temp.Add(buttons.ElementAt(i));
                        }
    
                    }
                    cards.Add(GetHeroCard(temp));
                }
            }
        }
    }
  
