    var state = activity.GetStateClient();
    var userdata = state.BotState.GetUserData(activity.ChannelId, activity.From.Id);
    var cultureInfo = userdata.GetProperty<CultureInfo>("lang");
    if (cultureInfo.Equals(new CultureInfo("de-DE")))
    {
        await Conversation.SendAsync(activity, () => new LUISDialogClassDe());
    }
    else
    {
        await Conversation.SendAsync(activity, () => new LUISDialogClassUs());
    }
