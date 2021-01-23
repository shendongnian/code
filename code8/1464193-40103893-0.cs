    /// <summary>
    /// POST: api/Messages
    /// Receive a message from a user and reply to it
    /// </summary>
    public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
    {
        // check if activity is of type message
        if (activity != null && activity.GetActivityType() == ActivityTypes.Message)
        {
            await Conversation.SendAsync(activity, () => new Dialogs.BillSharkDialog());
        }
        else
        {
            HandleSystemMessage(activity);
        }
        return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
    }
