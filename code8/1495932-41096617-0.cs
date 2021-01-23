    MailMessage Msg = new MailMessage();
    // Sender e-mail address.
    Msg.From = new MailAddress(txtEmail.Text);
    // Recipient e-mail address.
    Msg.To.Add("admin@abc.com");
    //Msg.Subject = txtSubject.Text;
    Msg.Body ="some body message";
    SmtpClient smtp = new SmtpClient();
    smtp.Host = "relay-hosting.secureserver.net";
    smtp.Send(Msg);
