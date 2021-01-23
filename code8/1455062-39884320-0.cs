    static void Main(string[] args)
            {
                try
                {
                    MailMessage message = new MailMessage();
                    message.Subject = "test";
                    message.Body = "test";
                    message.To.Add("atmane.elbouachri@gmail.com");
                    message.From = new MailAddress("atmane.elbouachri@softeam.fr");
                    SmtpClient smtp = new SmtpClient();
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Host = "127.0.0.1";
                    smtp.Port = 25;
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.ReadLine();
                }
            }
 
