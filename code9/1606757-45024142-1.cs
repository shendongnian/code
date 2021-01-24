        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
    {
        
        if (activity.Type == ActivityTypes.Message)
        {               
            try
            {
               await Conversation.SendAsync(activity, () => new RootDialog(activity.ChannelId));
            }
            catch (Exception e)
            {
                IActivity iActivity = activity as IActivity;
                await SendGetStarted(iActivity, activity);
            }
        }
        else
        {
            await HandleSystemMessage(activity);
        }
        if (activity.Text == "cancel")
        {
            IActivity iActivity = activity as IActivity;
            await SendGetStarted(iActivity, activity);
        }
        var response = this.Request.CreateResponse(HttpStatusCode.OK);
        return response;
    }
    
