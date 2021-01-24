    // Create a reply message
    Activity replyToConversation = activity.CreateReply();
    replyToConversation.Recipient = activity.From;
    replyToConversation.Type = "message";
    // Set the text containg the High Scores as the response
    replyToConversation.Text = sb.ToString();
    
    // Create a ConnectorClient and use it to send the reply message
     var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
    
    // Send the reply
    connector.Conversations.SendToConversationAsync(replyToConversation);
