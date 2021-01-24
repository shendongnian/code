    var state = activity.GetStateClient();
    var userdata = state.BotState.GetUserData(activity.ChannelId, activity.From.Id);
    var cultureInfo = userdata.GetProperty<CultureInfo>("lang");
    if (cultureInfo.Equals(new CultureInfo("us-EN")))
    {
        await Conversation.SendAsync(activity, () => new LUISDialogClassUS());
    }
    else
    {
        await Conversation.SendAsync(activity, () => new LUISDialogClassDE());
    }
