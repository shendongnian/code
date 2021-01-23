       if (leaveStatus == 1 && travelstatus==0)
                    { 
                        //nested if to check intents to follow
                        await Conversation.SendAsync(activity, BuildLeaveForm);
                        await connector.Conversations.ReplyToActivityAsync(activity.CreateReply("Thanks"));
                    }
                    else if(travelstatus == 1 && leaveStatus==0)
                    {
                        await Conversation.SendAsync(activity, BuildTravelForm);
                        await connector.Conversations.ReplyToActivityAsync(activity.CreateReply("Thanks"));
                    }
