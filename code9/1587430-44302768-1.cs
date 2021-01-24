      public void SendMail()
        {            
            SmtpClient smtpClient = new SmtpClient(<CLIENT>);
            MailMessage message = new MailMessage(<FROM>, <TO>);
            message.Subject = "Test";
            message.IsBodyHtml = true;
            string html = "<p>hey</p><p></p><p>hey 2</p><p>hey 3</p>";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html, new ContentType("text/html"));
            message.AlternateViews.Add(htmlView);
            smtpClient.Send(message);
        }
