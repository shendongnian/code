    //use the constructor without parameters        
    MailMessage notificationMessage = new MailMessage()
            {
            Subject = subject,
            Body = messageBodyText,
            IsBodyHtml = false,
            SubjectEncoding = Encoding.UTF8,
            BodyEncoding = Encoding.UTF8,
        };
    //add the To address later
        notificationMessage.To.Add(toAddress);
