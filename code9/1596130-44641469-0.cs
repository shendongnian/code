                if (activity.Type == ActivityTypes.Message)
            {
                if (activity.Text == "stop")
                {
                    activity = null;
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
            }
