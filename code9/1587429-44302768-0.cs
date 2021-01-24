           SmtpClient mailClient = new SmtpClient(<Client>);
            MailMessage msgMail = new MailMessage(<From>, <To>);
            msgMail.IsBodyHtml = true;
            string html =
                @"First line
    Secound line.
    Thank You";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html, new ContentType("text/plain"));
            msgMail.AlternateViews.Add(htmlView);
            mailClient.Send(msgMail);
