    MicrosoftAppCredentials.TrustServiceUrl(reference.ServiceUrl);
                var message = reference.GetPostToBotMessage();
                message.Value = new InternalEventMessage(type);
                message.Type = ActivityTypes.Event;
    
                await Conversation.ResumeAsync(reference, message);
