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
    
    		if (activity != null && activity.Text.ToLower().Contains("what is"))
    		{
    			await
    				context.Forward(new InternetSearchDialog(), this.ResumeAfterInternetSearchDialog, activity, CancellationToken.None);
    		}
    		else
    		{
    			// calculate something for us to return
    			int length = (activity.Text ?? string.Empty).Length;
    
    			// return our reply to the user
    			await context.PostAsync($"You sent {activity.Text} which was {length} characters. Thank you!");
                context.Wait(MessageReceivedAsync);
    		}		
    	}
    
    	private async Task ResumeAfterInternetSearchDialog(IDialogContext context, IAwaitable<string> result)
    	{
    		context.Wait(MessageReceivedAsync);
    	}
    }
