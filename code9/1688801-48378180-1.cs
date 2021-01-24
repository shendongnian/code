	/// <summary>
	/// Construct from an IActivity.
	/// </summary>
	/// <param name="activity"></param>
	public ActivityEntity(IActivity activity)
	{
		PartitionKey = GeneratePartitionKey(activity.ChannelId, activity.Conversation.Id);
		RowKey = GenerateRowKey(activity.Timestamp.Value);
		From = activity.From.Id;
		Recipient = activity.Recipient.Id;
		Activity = activity;
		Version = 3.0;
	}
