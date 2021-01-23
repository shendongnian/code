    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.Net.Mail;
    using System.Net;
    namespace SO_Question_2
    {
    class Program
    {
        static void Main(string[] args)
        {
            sendEmails();
        }
        private static void sendEmails()
        {
            List<string> emails = new List<string>();
            using (SqlConnection conn = new SqlConnection(@"Your Connection String"))
            {
                conn.Open();
                using (SqlCommand com = conn.CreateCommand())
                {
                    com.CommandText = "select user_Email from users where exireDate > @today";
                    com.Parameters.AddWithValue("@today", DateTime.Now.Date);
                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        emails.Add(Convert.ToString(read[0]));
                    }
                }
                conn.Close();
                string smtpAddress = "smtp.mail.yahoo.com";
                int portNumber = 587;
                bool enableSSL = true;
                string emailFrom = "yourAddress@yahoo.com";
                string password = "xxxxxx!";
                string subject = "Hello";
                string body = "Buy a new license!";
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    foreach (string recipient in emails)
                    {
                        mail.To.Add(recipient);
                    }
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    // Can set to false, if you are sending pure text.
                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }
            }
        }
    }
}
