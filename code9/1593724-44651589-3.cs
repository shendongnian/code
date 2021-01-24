        protected void Page_Load(object sender, EventArgs e)
        {
            var message = new MailMessage
            {
                From = new MailAddress(fromAddress, "Friendly Name"),
                Subject = "Test Friendly Name",
                Body = "Friendly name works !"
            };
            message.To.Add(recipient);
            var client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential
                {
                    UserName = username,
                    Password = password
                }
            };
            client.Send(message);
        }
