        private async Task MessageReceivedAsync(IDialogContext context, 
        IAwaitable<object> result)
        {
            var activity = await result as Activity;
            var response = activity.CreateReply();
            IMessageActivity reply = context.MakeMessage();
            
            if (activity.Text.ToLowerInvariant() == "do stuff")
            {
                activity.CreateReply("I have done the stuff");
                await context.PostAsync(activity);
            }
            else
            {
                List<CardAction> cardButtons = new List<CardAction>();
                CardAction Button = new CardAction
                {
                    Title = "do stuff",
                    //Type = ActionTypes.ImBack;  //this will display "do stuff" in the chat window
                    Type = ActionTypes.PostBack,  //same behavior except "do stuff" not displayed
                    Value = "do stuff"
                };
                
                cardButtons.Add(Button);
                HeroCard Card = new HeroCard()
                {
                    Buttons = cardButtons
                };
                Attachment plAttachment = Card.ToAttachment();
                reply.Attachments.Add(plAttachment);
                await context.PostAsync(reply);
            }
            context.Wait(MessageReceivedAsync);
        }
