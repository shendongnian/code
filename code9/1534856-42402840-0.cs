    public async Task Post(NotificationData notification)
    {
        using (MailMessage mail = new MailMessage())
        {
            mail.To.Add(new MailAddress(notification.Email));
            mail.Subject = notification.Subject;
            mail.Body = notification.Body;
            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.SendCompleted += new SendCompletedEventHandler(SmtpClient_SendCompleted);
                await smtp.SendMailAsync(mail);
            }
        }
    }
