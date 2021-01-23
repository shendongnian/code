    OpenPop.Mime.Message message = client.GetMessage(i);
    //Check you message is not null
    if(message != null){
    	OpenPop.Mime.MessagePart messagePart = message.MessagePart.MessageParts[1];
    
    	string test = messagePart.BodyEncoding.GetString(messagePart.Body);
    
    	dt.Rows.Add(new object[] { message.Headers.Subject, message.Headers.Sender, test, message.Headers.DateSent });
    }
