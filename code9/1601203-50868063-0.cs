    var msgRequest = service.Users.Messages.Get("me", msg.Id);
    msgRequest.Format = UsersResource.MessagesResource.GetRequest.FormatEnum.Raw;
    var msgDetails = msgRequest.Execute();
    
    using (MemoryStream rawInStream = new MemoryStream(Base64FUrlDecode(msgDetails.Raw)))
    using (MemoryStream rawOutStream = new MemoryStream())
    {
        var message = MimeKit.MimeMessage.Load(rawInStream);
        
        message.To.Clear();
        message.To.Add(new MimeKit.MailboxAddress("", "<email address>"));
        message.Subject = "Edited Subject";
        
        message.WriteTo(rawOutStream);
        msgDetails.Raw = Base64UrlEncode(rawOutStream.ToArray());
    }
    
    service.Users.Messages.Send(msgDetails, "me").Execute();
    
    private static byte[] Base64FUrlDecode(string input)
    {
        int padChars = (input.Length % 4) == 0 ? 0 : (4 - (input.Length % 4));
        StringBuilder result = new StringBuilder(input, input.Length + padChars);
        result.Append(String.Empty.PadRight(padChars, '='));
        result.Replace('-', '+');
        result.Replace('_', '/');
        return Convert.FromBase64String(result.ToString());
    }
    
    private static string Base64UrlEncode(byte[] input)
    {
        // Special "url-safe" base64 encode.
        return Convert.ToBase64String(input)
          .Replace('+', '-')
          .Replace('/', '_')
          .Replace("=", "");
    }
