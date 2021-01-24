    var message = response.MessageList.FirstOrDefault();
    var messageDetails = message.MessageDetailList
                                .Where(message => message.MessageCode.ToLower().Equals("status"))
                                .ToList();
    
    messageDetails.ForEach(status => status.MessageText = "Complete");
    
    messageDetails.ForEach(status => Debug.WriteLine(status.MessageText));
