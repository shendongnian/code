    public async Task ResumeAfterLocationReceived(IDialogContext context, IAwaitable<String> result)
    {
        if(result.Equals("no"))
        {
            await context.PostAsync(@"Sorry can't search");
            context.Wait(MessageReceived);
        }
        else
        {
            //added code here:
            var userSearchString = result.Text;
            Activity myActivity = new Activity();
            myActivity.Text = userSearchString ;
            await MessageReceived(context, Awaitable.FromItem(myActivity));
        }
    }
