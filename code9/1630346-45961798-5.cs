    bool IsValidEmail(string email)
    {
        try
        {
            return new System.Net.Mail.MailAddress(email).Address == email;
        }
        catch
        {
            return false;
        }
    }
