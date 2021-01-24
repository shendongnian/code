     Activity replyToConversation = activity.CreateReply("Quick Replies");
    
                    dynamic messageData = new JObject();
                    messageData.attachment = new JObject();
                    messageData.attachment.type = "template";
                    messageData.attachment.payload = new JObject();
                    messageData.attachment.payload.template_type = "generic";
    
    
                    messageData.attachment.payload.elements
                        = new JArray(
                            new JObject(
                                new JProperty("title", "hola"),
                                new JProperty("subtitle", "Mundo"),
                                new JProperty("buttons",
                                    new JArray(
                                        new JObject(
                                            new JProperty("type", "element_share")
                                        )
                                    )
                                )
                            )
                        );
    
    
                    replyToConversation.ChannelData = messageData;
                    ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                    await connector.Conversations.ReplyToActivityAsync(replyToConversation);
