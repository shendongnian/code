     private async Task<Activity> HandleSystemMessage(Activity message)
            {
                switch (message.Type)
                {
                    case ActivityTypes.ConversationUpdate: 
                        IConversationUpdateActivity update = message;
                        using (
                            var scope =
                                Microsoft.Bot.Builder.Dialogs.Internals.DialogModule.BeginLifetimeScope(Conversation.Container,
                                    message))
                        {
                            var client = scope.Resolve<IConnectorClient>();
                            if (!update.MembersAdded.Any()) return null;
                            foreach (var newMember in update.MembersAdded)
                            {
                                if (newMember.Id == message.Recipient.Id) continue;
                                await _configurationLibrary.MultiThreadLoadSettings();
                                var reply = message.CreateReply();
                                reply.Text = $"Shut up {username}";
                                await client.Conversations.ReplyToActivityAsync(reply);
                            }
                        }
                        break;
                }
                return null;
            }
