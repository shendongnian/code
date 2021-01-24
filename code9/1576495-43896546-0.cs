    using System;
    using System.Net.Mail;
    namespace XXX
    {
        class SendMessage
        {
            public void sendEmailMessage(){
               MailMessage mail = new MailMessage("test2@domain.com", "test@domain.com");
               SmtpClient client = new SmtpClient("mail.domain.com");
    
               client.UseDefaultCredentials = false;
               client.Port = 25;
               client.DeliveryMethod = SmtpDeliveryMethod.Network;
               //
               //mail.Subject = "this is a test email.";
               //mail.Body = "this is my test email body";
               //client.Send(mail);
            }
        }
    }
