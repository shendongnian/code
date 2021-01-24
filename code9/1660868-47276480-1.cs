    public static MimeKit.MimeMessage Reply(MimeKit.MimeMessage message, bool replyToAll)
    {
     var reply = new MimeKit.MimeMessage();
     if (message.ReplyTo.Count > 0)
      {
       reply.To.AddRange(message.ReplyTo);
      }
     else if (message.From.Count > 0)
      {
      reply.To.AddRange(message.From);
      }
      else if (message.Sender != null)
      {
      reply.To.Add(message.Sender);
      }
      if (replyToAll)
      {
      reply.To.AddRange(message.To);
      reply.Cc.AddRange(message.Cc);
      }
      if (!message.Subject.StartsWith("Re:", StringComparison.OrdinalIgnoreCase))
        reply.Subject = "Re:" + message.Subject;
      else
        reply.Subject = message.Subject;
      if (!string.IsNullOrEmpty(message.MessageId))
      {
        reply.InReplyTo = message.MessageId;
        foreach (var id in message.References)
          reply.References.Add(id);
          reply.References.Add(message.MessageId);
      }
      using (var quoted = new StringWriter())
      {
        var sender = message.Sender ?? message.From.Mailboxes.FirstOrDefault();
        quoted.WriteLine("On {0}, {1} wrote:", message.Date.ToString("f"), !string.IsNullOrEmpty(sender.Name) ? sender.Name : sender.Address);
        using (var reader = new StringReader(message.TextBody))
        {
          string line;
          while ((line = reader.ReadLine()) != null)
          {
            quoted.Write("> ");
            quoted.WriteLine(line);
          }
        }
        reply.Body = new MimeKit.TextPart("plain")
        {
          Text = quoted.ToString()
        };
      }
      return reply;
    }
