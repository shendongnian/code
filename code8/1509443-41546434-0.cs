     public static void SendMail(MailMessage Msg)
        {
            SmtpClient _SMTP = new SmtpClient(SMTP, SMTP_Port);
            _SMTP.UseDefaultCredentials = false;
            _SMTP.Credentials = new System.Net.NetworkCredential(User, Password);
            _SMTP.Send(Msg);
        }
