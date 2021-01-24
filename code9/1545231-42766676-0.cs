    var client = new SmtpClient();
    var message = new MailMessage("helloworld@gmail.com", txtEmail.Text);
    var subject = txtSubject.Text;
    var body = txtMessageBody.Text;
    message.Subject = subject;
    mail.Body = body;
    client.Send(message);
