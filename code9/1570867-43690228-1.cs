    public bool IsEmailValid(string address)
    {
        try
        {
            MailAddress m = new MailAddress(address);
            return true;
        }
        catch (FormatException)
        {
           return false;
        }
    }
