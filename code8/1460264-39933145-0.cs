        {
            emailID = "";
            // Nova Mensagem 
            var message = new MimeMessage();
            try
            {
                // Acede aos parâmetros do email caso este seja do gestobrigweb gmail.com
                if (emailSettings.email == "gestobrigweb@gmail.com") {
                    EmailProvider provider = new EmailProviders().GetEmailProvider(Convert.ToInt32(ConfigurationManager.AppSettings["gestObrigWebProviderID"]));
                    if (emailSettings.provider == null)
                        emailSettings.provider = provider;
                }
                // UserName
                string userName = emailSettings.email;   
                // Password
                if (userPass == "")
                    userPass = cripter.Decrypt(emailSettings.pass);
                // From
                message.From.Add(new MailboxAddress(emailSettings.email, emailSettings.email));
                // TO
                if (recipient.Contains(";"))
                    foreach (string recipt in recipient.Split(';'))
                        message.To.Add(new MailboxAddress(recipt, recipt));
                else
                    if (recipient.Contains(","))
                        foreach (string recipt in recipient.Split(','))
                            message.To.Add(new MailboxAddress(recipt, recipt));
                    else
                      message.To.Add(new MailboxAddress(recipient, recipient));
              
                
                // Se Assume CC
                if (assumeCC)
                    message.Cc.Add(new MailboxAddress(emailSettings.email,emailSettings.email));
                // Destinatário
                if (cc != "")
                {
                    if (cc.Contains(";"))
                        foreach (string emailCC in cc.Split(';'))
                        message.Cc.Add(new MailboxAddress(emailCC,emailCC));
                    else
                        message.Cc.Add(new MailboxAddress(cc, cc));
                }
                // Assunto
                message.Subject = subject;
                // Body (Mensagem)
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = body;
                message.Body = bodyBuilder.ToMessageBody();
 
                // Envio
                using (var client = new SmtpClient())
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect(emailSettings.emailServer, emailSettings.serviceType, false);
                    // Note: since we don't have an OAuth2 token, disable
                    // the XOAUTH2 authentication mechanism.
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(userName, userPass);
                    client.Send(message);
                    client.Disconnect(true);
                    return true;
                }
            }
