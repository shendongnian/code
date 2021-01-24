    public bool UpdatePasswordForToken(string token, string newPassword)
    {
    	bool success = false;
    
    	var user = Context.Users.SingleOrDefault(u => u.ResetToken.Equals(token, StringComparison.OrdinalIgnoreCase));
    	if (user != null)
    	{
    		var password = Crypto.HashPassword(newPassword);
    		if (!string.IsNullOrWhiteSpace(password))
    		{
    			user.Password = password;
    			user.ResetToken = null;
    
    			Context.SaveChanges();
    
    			success = true;
    		}
    	}
    
    	return success;
    }
