            public async Task LogAsync(IActivity activity)
            {
                var conversation = "";
                var convActivity = "";
                conversation = $"From: {activity.From.Name} \n\n To: {activity.Recipient.Name} \n\n Message: {activity.AsMessageActivity()?.Text}";
                convActivity = convActivity + conversation;
            }
  
