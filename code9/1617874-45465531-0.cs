    var newMessage = context.MakeMessage();
    newMessage.Text = this.originalMessageText //the variable that contains the text of the original message that you will have to save at MessageReceiveAsync
    await context.Forward(new EnglishLuis(), ResumeAfterDialog, newMessage, CancellationToken.None);
    MessageReceivedAsync in RootDialog should looks like:
    
     private async Task MessageReceiveAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var reply = await result;
            if (reply.Text.ToLower().Contains("help"))
            {
                await context.PostAsync("You can implement help menu here");
            }
            else
            {
                this.originalMessage = reply.Text;
                await ShowMainmenu(context);
            }
        }
