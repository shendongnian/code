    public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
            {
                if (activity.Type == ActivityTypes.Message)
                {
                      if (string.IsNullOrEmpty(activity.Text))
                         {
                              var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
    
                              Activity reply = activity.CreateReply();
                              reply.Text = string.Format(Resources.WELCOME_MESSAGE, Constants.UserInfo.FullName);
                              reply.Speak = SSMLHelper.Speak(string.Format(Resources.WELCOME_MESSAGE, Constants.UserInfo.FullName));
                              reply.InputHint = InputHints.ExpectingInput;
    
                              await connector.Conversations.ReplyToActivityAsync(reply);
                         }
                     else
                        {
                              await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
                         }
                }
                else
                {
                    await HandleSystemMessage(activity);
                }
    
                var response = Request.CreateResponse(HttpStatusCode.OK);
                return response;
            }
