        [Serializable]
        public class RootDialog : IDialog<object>
        {
            //private static IEnumerable<string> options = new List<string> { GlobalResources.AboutToro, GlobalResources.Investiments, GlobalResources.IsThereAnyRisk, GlobalResources.ResourceDeposits, GlobalResources.Access_LoginAndPasswords, GlobalResources.AccountOpening };
            public async Task StartAsync(IDialogContext context)
            {
                context.Wait(MessageReceivedAsync);
            }
    
            private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
            {
                var message = await result;
    
                if (message.Text == null || message.Text.Equals(GlobalResources.Back, StringComparison.InvariantCultureIgnoreCase))
                {   //Quando entra nesse diálogo a 1ª vez ou volta de um dialogo filho.
                    var rootCard = GetCard();
    
                    var reply = context.MakeMessage();
                    reply.Attachments.Add(rootCard);
    
                    await context.PostAsync(reply);
                    context.Wait(MessageReceivedAsync);
                }
                else if (message.Text.Equals(GlobalResources.AboutToro, StringComparison.InvariantCultureIgnoreCase))
                {
                    context.Call(new AboutToroDialog(), OnResumeToRootDialog);
                }
                else
                {
                    var messageToForward = await result;
                    await context.Forward(new QnADialog(), AfterFAQDialog, messageToForward, CancellationToken.None);
                    return;
                }
            }
    
            private async Task AfterFAQDialog(IDialogContext context, IAwaitable<object> result)
            {
                //var messageHandled = await result;
                //if ((bool)messageHandled == true)
                //{
                //    await context.PostAsync("Sorry, I wasn't sure what you wanted.");
                //}
    
                context.Wait(MessageReceivedAsync);
            }
    
            private async Task OnResumeToRootDialog(IDialogContext context, IAwaitable<IMessageActivity> result)
            {
                await MessageReceivedAsync(context, result);
            }
    
            private Attachment GetCard()
            {
                var buttons = new List<CardAction>
                {
                    new CardAction()
                    {
                        Title = GlobalResources.AboutToro,
                        Type = ActionTypes.ImBack,
                        Value = GlobalResources.AboutToro
                    },
                    new CardAction()
                    {
                        Title = GlobalResources.IsThereAnyRisk,
                        Type = ActionTypes.ImBack,
                        Value = GlobalResources.IsThereAnyRisk
                    },
                    new CardAction()
                    {
                        Title = GlobalResources.ResourceDeposits,
                        Type = ActionTypes.ImBack,
                        Value = GlobalResources.ResourceDeposits
                    },
                    new CardAction()
                    {
                        Title = GlobalResources.Access_LoginAndPasswords,
                        Type = ActionTypes.ImBack,
                        Value = GlobalResources.Access_LoginAndPasswords
                    },
                    new CardAction()
                    {
                        Title = GlobalResources.AccountOpening,
                        Type = ActionTypes.ImBack,
                        Value = GlobalResources.AccountOpening
                    },
                };
    
                var images = new List<CardImage>
                {
                    new CardImage("http://is1.mzstatic.com/image/thumb/Purple117/v4/b8/d5/5e/b8d55e77-d70e-f22b-17b7-2498d974a4fe/source/175x175bb.jpg")
                };
    
                return new HeroCard("Em que posso te ajudar ?", "subtitle", "bla bla bla",images, buttons).ToAttachment();
            }
    
        }
    }
