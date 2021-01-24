    case ActivityTypes.Message:
    
    	if (!string.IsNullOrEmpty(activity.Text) && activity.Text.ToLower() == "history")
    	{
    		using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, activity))
    		{
    			var reply = activity.CreateReply();
    			var storedActivities = new List<IActivity>();
    			var found = Logger.Messages.TryGetValue(activity.Conversation.Id, out storedActivities);
    			if (storedActivities != null)
    			{
    				foreach (var storedActivity in storedActivities)
    				{
    					reply.Text += $"\n\n {storedActivity.From.Name}: {storedActivity.AsMessageActivity().Text}";
    				}
    			}
    			else
    			{
    				reply.Text = "no history yet";
    			}
    
                //or, send an email here...
    			var client = scope.Resolve<IConnectorClient>();
    			await client.Conversations.ReplyToActivityAsync(reply);
    		}                               
    	}
    	else
    		await Conversation.SendAsync(activity, MakeRootDialog);
    	break;
