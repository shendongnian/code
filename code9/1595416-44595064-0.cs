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
                            Activity replyToConversation = message.CreateReply("Should go to conversation");
                            replyToConversation.Attachments = new List<Attachment>();
                            AdaptiveCard card = new AdaptiveCard();
                            // Specify speech for the card.
                            card.Speak = "<s>Your  meeting about \"Adaptive Card design session\"<break strength='weak'/> is starting at 12:30pm</s><s>Do you want to snooze <break strength='weak'/> or do you want to send a late notification to the attendees?</s>";
                            // Add text to the card.
                            card.Body.Add(new TextBlock()
                            {
                                Text = "Adaptive Card design session",
                                Size = TextSize.Large,
                                Weight = TextWeight.Bolder
                            });
                            // Add text to the card.
                            card.Body.Add(new TextBlock()
                            {
                                Text = "Conf Room 112/3377 (10)"
                            });
                            // Add text to the card.
                            card.Body.Add(new TextBlock()
                            {
                                Text = "12:30 PM - 1:30 PM"
                            });
                            // Add list of choices to the card.
                            card.Body.Add(new ChoiceSet()
                            {
                                Id = "snooze",
                                Style = ChoiceInputStyle.Compact,
                                Choices = new List<Choice>()
                                {
                                    new Choice() { Title = "5 minutes", Value = "5", IsSelected = true },
                                    new Choice() { Title = "15 minutes", Value = "15" },
                                    new Choice() { Title = "30 minutes", Value = "30" }
                                }
                            });
                            // Add buttons to the card.
                            card.Actions.Add(new HttpAction()
                            {
                                Url = "http://foo.com",
                                Title = "Snooze"
                            });
                            card.Actions.Add(new HttpAction()
                            {
                                Url = "http://foo.com",
                                Title = "I'll be late"
                            });
                            card.Actions.Add(new HttpAction()
                            {
                                Url = "http://foo.com",
                                Title = "Dismiss"
                            });
                            // Create the attachment.
                            Attachment attachment = new Attachment()
                            {
                                ContentType = AdaptiveCard.ContentType,
                                Content = card
                            };
                            replyToConversation.Attachments.Add(attachment);
                            var reply = await connector.Conversations.SendToConversationAsync(replyToConversation);
                        }
                    }
                }
            }
