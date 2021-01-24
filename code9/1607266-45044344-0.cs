    var replyMessage = await graphClient.Me.Messages[message.Id].CreateReply().Request().PostAsync();
    var newReplyBody = new ItemBody();
    newReplyBody.Content = "Response" + replyMessage.Body.Content;
    replyMessage.Body = newReplyBody;
    replyMessage.Subject = "New Subject";
    await graphClient.Me.Messages[replyMessage.Id].Request().UpdateAsync(replyMessage);
    
    await graphClient.Me.Messages[replyMessage.Id].Send().Request().PostAsync();
