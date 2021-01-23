        public static bool IsValidEmail(this string email)
    {
        bool rt = false;
        try
        {
            var mail = new System.Net.Mail.MailAddress(email);
            rt = mail.Host.Contains(".");
        }
        catch { }
        return rt;
    }
