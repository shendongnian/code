    public static bool saveData(Activity activity, string key, string value)
    {
        StateClient stateClient = activity.GetStateClient();
        BotData userData = stateClient.BotState.GetUserData(activity.ChannelId, activity.From.Id);
        userData.SetProperty<string>(key, value);
        BotData updateResponse = stateClient.BotState.SetUserData(activity.ChannelId, activity.From.Id, userData);
        return value == updateResponse.GetProperty<string>(key);
    }
