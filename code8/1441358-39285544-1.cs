    public string GetMail(){
    GmailService service = (GmailService)HttpContext.Current.Session["service"];
    Message messageFeed = service.Users.Messages.List("me").Execute().Messages.First();
    UsersResource.MessagesResource.GetRequest getReq = new UsersResource.MessagesResource.GetRequest(service, "me", messageFeed.Id);
     //"raw": Returns the full email message data with body content in the raw field as a base64url encoded string; the payload field is not used. 
    getReq.Format = UsersResource.MessagesResource.GetRequest.FormatEnum.Raw;
     Message message = getReq.Execute();
    return message.Raw;
    }
