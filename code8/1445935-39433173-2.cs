        public IActionResult SendEmail(Contact contact)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("myname", "mymail@mail.com"));
            emailMessage.To.Add(new MailboxAddress("myname", "mymail@mail.com"));
            emailMessage.Subject = contact.Subject;
            emailMessage.Body = new TextPart("plain") 
            { 
             Text = String.Format("This visitor:{0} with this email:{1} Send this message:{2}", 
             contact.Name, contact.Email, contact.Message) 
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp-mail.outlook.com", 587);
                client.Authenticate("myemail", "myemailpassword");
                client.Send(emailMessage);
                client.Disconnect(true);
            }
            return RedirectToAction("Index", "Home");
        }
