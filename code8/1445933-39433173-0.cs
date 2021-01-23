    public IActionResult SendEmail(Contact contact)
    {
        var emailMessage = new MimeMessage();
    emailMessage.From.Add(new MailboxAddress("myname", "mymail@mail.com"));
    emailMessage.To.Add(new MailboxAddress(contact.Name, contact.Email));
    emailMessage.Subject = contact.Subject;
    emailMessage.Body = new TextPart("plain") { Text = contact.Message };
    using (var client = new SmtpClient())
    {
        client.Connect("smtp-mail.outlook.com", 587); 
        client.Authenticate("myemail", "myemailpassword");
        client.Send(emailMessage);
        client.Disconnect(true);
    }
    return RedirectToAction("Index", "Home");
    }
