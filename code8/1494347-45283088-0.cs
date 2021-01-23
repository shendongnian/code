        [Serializable]
        public class RootDialog : IDialog<object>
        {
                public async Task StartAsync(IDialogContext context)
                {
                    context.Wait(ConversationStartedAsync);
                }
    
                public async Task ConversationStartedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
                {
                    var message = await argument;
                    PromptDialog.Text(
                        context: context,
                        resume: AfterNameInput,
                        prompt: "Hi! what's your name?",
                        retry: "Sorry, I didn't get that.");
    
                }
    
                public async Task AfterNameInput(IDialogContext context, IAwaitable<string> result)
                {
                    var name = await result;
                //Set value in the context, like holding value in ASP.NET Session
                context.PrivateConversationData.SetValue<string>("Name", name);
    
                    PromptDialog.Choice(context, this.ResumeAfterTakingGender, new[] { "Male", "Female" }, "Please enter your gender", "I am sorry I didn't get that, try selecting one of the options below", 3);
                }
    
            private async Task ResumeAfterTakingGender(IDialogContext context, IAwaitable<string> result)
            {
                string gender = await result;
    
                string name = string.Empty;
                
                //Get the data from the context
                context.PrivateConversationData.TryGetValue<string>("Name", out name);
    
                await context.PostAsync($"Hi {name} you are a {gender}");
    
                //Gracefully exit the dialog, because its implementing the IDialog<object>, so use 
                context.Done<object>(null);
            }
          }
        }
