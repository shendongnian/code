    using System.Net.Mail;
    using System.Text;
   
    // SMTP host.
         
         try
         {
         SmtpClient client = new SmtpClient();
         client.Port = 587;
         client.Host = "smtp.gmail.com";
         client.EnableSsl = true;
         client.Timeout = 10000;
         client.DeliveryMethod = SmtpDeliveryMethod.Network;
         client.UseDefaultCredentials = false;
         client.Credentials = new System.Net.NetworkCredential("Sender@gmail.com","SenderPassword");
         MailMessage mm = new MailMessage("Sender@gmail.com", "Receiver@gmail.com", "test", "test");
         mm.BodyEncoding = UTF8Encoding.UTF8;
         mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
         client.Send(mm);
         }
         catch (Exception ex)
         {
             Console.WriteLine("Exception caught in CreateCopyMessage():{0}",
             ex.ToString());
         }
