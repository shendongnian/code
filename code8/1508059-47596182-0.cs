        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            // ... some code ...
            // this will also handle the beginning of the conversation - 
            // that is when activity.Type equals to ConversationUpdate
            if (activity.Type == ActivityTypes.Message 
                || activity.Type == ActivityTypes.ConversationUpdate)
            {
                // Because ConversationUpdate activity is received twice 
                // (once for the Bot being added to the conversation, and the 2nd time - 
                // for the user), we have to filter one out, if we don't want the dialog 
                // to get started twice. Otherwise the user will receive a duplicate message.
                if (activity.Type == ActivityTypes.ConversationUpdate && 
                   !activity.MembersAdded.Any(r => r.Name == "Bot"))
                    return response;
                // start your root dialog here
                await Microsoft.Bot.Builder.Dialogs.Conversation.SendAsync(activity, () =>
                new ExceptionHandlerDialog<object>(new ShuttleBusDialog(), displayException: true));
            }
            // handle other types of activity here (other than Message and ConversationUpdate 
            // activity types)
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(System.Net.HttpStatusCode.OK);
            return response;
        }
