               var fromAddress = new MailAddress("fromAddress", "My Name");
                var toAddress = new MailAddress("gtoAddress ", "Mr Test");
                const string fromPassword = "fromPassword";
                string subject = "hello";
                string body = "how are you doing?";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
