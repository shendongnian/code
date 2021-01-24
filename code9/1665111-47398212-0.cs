    var connectorClient = new ConnectorClient(new Uri(activity.ServiceUrl));
                    var reply = ((Activity)activity).CreateReply("Question 1");
                    reply.Type = ActivityTypes.Message;
                    reply.TextFormat = TextFormatTypes.Plain;
    
                    reply.SuggestedActions = new SuggestedActions()
                    {
                        Actions = new List<CardAction>()
                        {
                            new CardAction() {Title = "Ans 1", Type = ActionTypes.PostBack, Value = "question 1 Ans 1"},
                            new CardAction() {Title = "Ans 2", Type = ActionTypes.PostBack, Value = "question 1 Ans 2"}
                        }
                    };
                    await connectorClient.Conversations.ReplyToActivityAsync(reply);
    
    
                    //Question 2 after 10 sec
                    reply = ((Activity)activity).CreateReply("Question 2");
                    reply.Type = ActivityTypes.Message;
                    reply.TextFormat = TextFormatTypes.Plain;
    
                    reply.SuggestedActions = new SuggestedActions()
                    {
                        Actions = new List<CardAction>()
                        {
                            new CardAction() {Title = "Ans 1", Type = ActionTypes.PostBack, Value = "question 2 Ans 1"},
                            new CardAction() {Title = "Ans 2", Type = ActionTypes.PostBack, Value = "question 2 Ans 2"}
                        }
                    };
                    await connectorClient.Conversations.ReplyToActivityAsync(reply);
