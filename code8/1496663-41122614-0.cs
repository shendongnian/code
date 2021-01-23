    private bool IsValid(string email, string password)
    {
    	var crypto = new SimpleCrypto.PBKDF2();
    	bool IsValid = false;
    
    	using (AppContext db = new AppContext())
    	{
    		var user = db.Users.FirstOrDefault(u => u.Email == email);
    		if (user != null)
    		{
    			if (user.Password == crypto.Compute(password, user.PasswordSalt))
    			{
    				IsValid = true;
    			}
    		}
    	}
    	return IsValid;
    }
