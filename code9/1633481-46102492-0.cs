       public static T GetStateData<T>(Activity activity, string key)
        {
            BotState botState = new BotState(activity.GetStateClient());
            BotData botData = botState.GetConversationData(activity.ChannelId, activity.Conversation.Id);
            return botData.GetProperty<T>(key);
        }
