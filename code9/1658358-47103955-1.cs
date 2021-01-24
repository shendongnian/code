    [Serializable]
        public class RootDialogTest : IDialog<object>
        {
            public async Task StartAsync(IDialogContext context)
            {
                context.Wait(NameReceivedAsync);
            }
    
            private async Task NameReceivedAsync(IDialogContext context, IAwaitable<object> result)
            {
                var activity = await result as Activity;
    
                if (!context.UserData.ContainsKey("askedname"))
                {
                    await context.PostAsync("Olá! Eu sou um bot!");
                    await context.PostAsync("Qual é o teu nome?");
                    context.UserData.SetValue("askedname", true);
                    context.Wait(NameReceivedAsync);
                }
                else
                {
                    var userName = activity.Text;                
                    await context.PostAsync($"Olá {userName}. Podes dizer alguma coisa e eu vou repetir.");
                    context.Wait(MessageReceivedAsync);
                }
            }
    
            private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
            {
                var activity = await result as Activity;
    
                // calculate something for us to return
                int length = (activity.Text ?? string.Empty).Length;
    
                // return our reply to the user
                await context.PostAsync($"Tu disseste { activity.Text}, que tem {length} caracteres");
    
                context.Wait(MessageReceivedAsync);
            }
        }
