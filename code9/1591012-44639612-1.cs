                else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                IConversationUpdateActivity iConversationUpdated = message as IConversationUpdateActivity;
                if (iConversationUpdated != null)
                {
                    ConnectorClient connector = new ConnectorClient(new System.Uri(message.ServiceUrl));
                    foreach (var member in iConversationUpdated.MembersAdded ?? System.Array.Empty<ChannelAccount>())
                    {
                        // if the bot is added, then
                        if (member.Id == iConversationUpdated.Recipient.Id)
                        {
                            var reply = ((Activity)iConversationUpdated).CreateReply($"Hi Friend I'm Botty McBotface");
                            connector.Conversations.ReplyToActivityAsync(reply);
                        }
                    }
                }
            }
