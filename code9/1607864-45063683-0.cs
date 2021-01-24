        public static void Send(string to, string subject)
        {
              MailMessage mail = new MailMessage("example@example.com", to);
              mail.IsBodyHtml = true;
              SmtpClient client = new SmtpClient();
              client.Port = 25;
              client.DeliveryMethod = SmtpDeliveryMethod.Network;
              client.UseDefaultCredentials = false;
              client.EnableSsl = false;
              client.Credentials = new 
              NetworkCredential("example@example.com", "password");
              client.Host = "YOURHOST";
              mail.Subject = subject;
              mail.Body = body;
              client.Send(mail);
        }
