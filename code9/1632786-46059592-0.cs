    public async Task<ActionResult> EmailMethod()
            {
                IdentityMessage emailMessage = new IdentityMessage
                {
                    Destination = recipient.Email,
                    Subject = "You have a new message - " + message.Subject,
                    Body = "<p>Message from: " + recipient.UserName + "</p>" + message.Body
                };
                EmailService emailService = new EmailService();
                await emailService.SendAsync(emailMessage);
                return View();
            }
