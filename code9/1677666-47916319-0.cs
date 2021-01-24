    public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
    {
        if (activity.Type == ActivityTypes.Message)
        {
            if ([determine if this will take > 15s]) 
	        {
                // process the message asyncronously
                Task.Factory.StartNew(async () => await Conversation.SendAsync(activity, () => new Dialogs.RootDialog()));
            }
	        else
	        {
                //process the message normally
                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
            }
        }
        return Request.CreateResponse(HttpStatusCode.OK); //ack the call
    }
