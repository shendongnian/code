    readonly Regex EmailRegex = new Regex (@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
    public bool ValidateEmail(string email)
    {
    	if (string.IsNullOrWhiteSpace(email))
    		return false;
    
    	return EmailRegex.IsMatch(email);
    }
