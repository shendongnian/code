    var emailInfoReq = service.Users.Messages.Get("me", email.Id);
    emailInfoReq.Format = UsersResource.MessagesResource.GetRequest.FormatEnum.Raw; 
    var emailInfoResponse = emailInfoReq.Execute();
    if (emailInfoResponse != null)
    {
      var message = emailInfoResponse.Raw;
      byte[] Msg = Base64UrlDecode(message);
      MemoryStream mm = new MemoryStream(Msg);
      MimeKit.MimeMessage Message1  = MimeKit.MimeMessage.Load(mm);
      MimeKit.MimeMessage Message = Reply(Message1, false);
      Message message1 = new Message();
      message1.Raw = Base64UrlEncode(Message.ToString());
      var result = service.Users.Messages.Send(message1, "me").Execute();
    }
