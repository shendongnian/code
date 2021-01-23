    public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
    {
       var message = await result;
    
       if (IsCancel(message.Text)) 
       {
         context.Done<string>(null);
       }
       // rest of the code of this method..
    }
