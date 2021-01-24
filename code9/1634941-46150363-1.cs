    public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                Activity isTypingReply = activity.CreateReply();
                isTypingReply.Type = ActivityTypes.Typing;
                HandleSystemMessage(isTypingReply); //I passed the activity type to the HandleSystemMessage and let it handle the typingActivity;
                await Conversation.SendAsync(activity, () => new YourDialog());
            }  
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
