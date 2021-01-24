            var apiKey = AppConstants.JuketserSendGridKey;
            var client = new SendGridClient(apiKey);
            
            var msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress("admin@jukester.com", "Jukester"));
            //msg.SetSubject("I'm replacing the subject tag");
            msg.AddTo(new EmailAddress(model.EmailTo));
            //msg.AddContent(MimeType.Text, "I'm replacing the <strong>body tag</strong>");
            msg.SetTemplateId("Your TemplateId here");
            
            var response = await client.SendEmailAsync(msg);
            var status = response.StatusCode.ToString();
