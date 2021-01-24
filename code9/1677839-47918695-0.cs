    public static class EncryptDecrypt
    {
    	private static string sEncryptionPassphrase = "B@|@j!";
    
    	public static string Encrypt(string stringToEncrypt)
    	{
    		try
    		{
    			string returnstring;
    			var salt = GenerateSalt();
    			using (var keyBytes = new Rfc2898DeriveBytes(sEncryptionPassphrase, salt))
    			{
    				var key = keyBytes.GetBytes(8);
    
    				DESCryptoServiceProvider des = new DESCryptoServiceProvider();
    				des.GenerateIV();
    				byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
    				System.IO.MemoryStream ms = new System.IO.MemoryStream();
    				CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, des.IV), CryptoStreamMode.Write);
    				cs.Write(inputByteArray, 0, inputByteArray.Length);
    				cs.FlushFinalBlock();
    				returnstring = Convert.ToBase64String(ms.ToArray());
    			}
    
    			//URL Encryption Avoid Reserved Characters
    			returnstring = returnstring.Replace("/", "-2F-");
    			returnstring = returnstring.Replace("+", "-2B-");
    			returnstring = returnstring.Replace("=", "-3D-");
    
    			return returnstring;
    		}
    		catch (Exception e)
    		{
    			return e.Message;
    		}
    	}
    
    	private static byte[] GenerateSalt()
    	{
    		var randomBytes = new byte[8];
    		using (var rngCsp = new RNGCryptoServiceProvider())
    		{
    			rngCsp.GetBytes(randomBytes);
    		}
    		return randomBytes;
    	}
    }
