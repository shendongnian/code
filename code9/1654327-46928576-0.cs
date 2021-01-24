	if (activity.Type == ActivityTypes.Message)
	{
		try
		{
			if (activity.Attachments.Count > 0)
			{
				var replyNoAttachmentAllowed = activity.CreateReply("This QnA bot cannot handle attachments, please send only text");
				await context.PostAsync(replyNoAttachmentAllowed);
			}
			else
			{
				// Check in QnA Dialog
				await Conversation.SendAsync(activity, () => new QnADialog());
			}
		}
		catch (Exception ex)
		{
			throw;
		}
	}
