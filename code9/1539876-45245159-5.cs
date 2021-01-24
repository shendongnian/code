    <pre>public async Task SendAsync(IdentityMessage message)
    {
        MailMessage email = new MailMessage(new MailAddress("youremailadress@domain.com", "(any subject here)"),
        new MailAddress(message.Destination));
        email.Subject = message.Subject;
        email.Body = message.Body;
        email.IsBodyHtml = true;
        GmailEmailService mailClient = new GmailEmailService();
        await mailClient.SendMailAsync(email);
    }</pre>
