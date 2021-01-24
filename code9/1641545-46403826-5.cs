    using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
    {
        smtp.Send(message); //IN SCOPE
    }
    smtp.Send(message); //THIS WOULD BE OUT OF SCOPE
