    var client = new SmtpClient();
    client.Port = 587;
    client.DeliveryMethod = SmtpDeliveryMethod.Network;
    client.UseDefaultCredentials = false;
    if (!client.UseDefaultCredentials)
    client.Credentials = new System.Net.NetworkCredential("your_email@mail.com", "your_email_pass");
    client.EnableSsl = true;
    client.Host = "smtp.gmail.com";
    var mail = new MailMessage("from@mail.com", "to@mail.com");
    mail.Subject = "test ";
    mail.Body = "body message";
    mail.IsBodyHtml = true;
    client.Send(mail);
