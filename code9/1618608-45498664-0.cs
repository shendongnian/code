    using System.Net.Mail;
. 
    MailMessage mail = new MailMessage("example@gmail.com", "example@gmail.com", "Title","Body");
                        SmtpClient client = new SmtpClient();
                        client.Host = ("smtp.gmail.com");
                        client.Port = 587; //smtp port for SSL
                        client.Credentials = new System.Net.NetworkCredential("example@gmail.com", "password");
                        client.EnableSsl = true; //for gmail SSL must be true
                        client.Send(mail);
