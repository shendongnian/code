            private static string smtp_address = "";
            private static int smtp_port = 587;
            private static string smtp_user = "";
            private static string smtp_password = "";
            private static bool smtp_ssl = false;
            private bool SendMassEmail(string from, string to, string cc, string subject, string message, string body)
            {
                smtp_address = WebConfigurationManager.AppSettings["Host"];
                smtp_port = int.Parse(WebConfigurationManager.AppSettings["Port"]);
                smtp_user = new System.Net.NetworkCredential(WebConfigurationManager.AppSettings["UserName"];
                smtp_password = WebConfigurationManager.AppSettings["Password"]);
                smtp_ssl = smtp_ssl;
    
                MailMessage mm = new MailMessage(from, to, subject, message);
                SmtpClient smtp = new SmtpClient(smtp_address, smtp_port);
                smtp.Credentials = new NetworkCredential(smtp_user, smtp_password);
                smtp.EnableSsl = smtp_ssl;
    
                smtp.Send(mm);
                return true;
            }
