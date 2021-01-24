    public static string GenPasswordString(string password, string salt)
    {
    	byte[] bytes = System.Text.Encoding.UTF8.GetBytes(salt + password);
    	using (var alg = new System.Security.Cryptography.SHA1Managed())
    	{
    		byte[] hashBytes = alg.ComputeHash(bytes);
    		return Convert.ToBase64String(hashBytes);
    	}
    }
