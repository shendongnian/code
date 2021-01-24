        private void SendIt()
        {
            var fromAddress = "";
            var toAddress = "";
            //Password of your gmail address
            const string fromPassword = "";
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "";
                smtp.Port = 25;
                smtp.EnableSsl = false;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            MailMessage msg = new MailMessage();
            MailAddress ma = new MailAddress(fromAddress);
            msg.To.Add(toAddress);
            msg.From = ma;
            msg.Attachments.Add(new Attachment(@"C:\temp\myreport.log"));
            msg.Body = "Your body message";
            msg.Subject = "Your subject line";
            smtp.Send(msg);
        }
