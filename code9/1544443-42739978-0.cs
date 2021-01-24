    void Main()
    {
    	CryptDecrypt cd = new CryptDecrypt(new Guid());
    	string s = cd.Encrypt("Password");
    	Console.WriteLine(s);
    	string t = cd.Decrypt(s);
    	Console.WriteLine(t);
    }
    
    public class CryptDecrypt
    {
    	private byte[] Key;
    	private byte[] IV;
    	public CryptDecrypt(Guid keyBase)
    	{
    		string Hash = keyBase.ToString();
    		Key = Encoding.UTF8.GetBytes(Hash.Take(32).ToArray());
    		IV = Encoding.UTF8.GetBytes(Hash.Reverse().Take(16).ToArray());
    	}
    
    
    	public string Encrypt(string plainText)
    	{
    
    		byte[] encrypted;
    		// Create an Aes object
    		// with the specified key and IV.
    		using (Aes aesAlg = Aes.Create())
    		{
    			aesAlg.IV = IV;
    			aesAlg.Key = Key;  <- HERE
    			aesAlg.Padding = PaddingMode.Zeros;
    			// Create a decrytor to perform the stream transform.
    			ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
    
    			// Create the streams used for encryption.
    			using (MemoryStream msEncrypt = new MemoryStream())
    			{
    				using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
    				{
    					using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
    					{
    						//Write all data to the stream.
    						swEncrypt.Write(plainText);
    						swEncrypt.Flush();
    					}
    					encrypted = msEncrypt.ToArray();
    				}
    			}
    		}
    
    		return Convert.ToBase64String(encrypted);
    	}
    
    	public string Decrypt(string inputStr)
    	{
    		// Check arguments.
    		if (inputStr == null || inputStr.Length <= 0)
    			throw new ArgumentNullException("cipherText");
    			
    		byte[] cipherText = Convert.FromBase64String(inputStr); <- HERE
    
    		// Declare the string used to hold
    		// the decrypted text.
    		string plaintext = null;
    
    		// Create an Aes object
    		// with the specified key and IV.
    		using (Aes aesAlg = Aes.Create())
    		{
    			aesAlg.Key = Key;
    			aesAlg.IV = IV;
    			aesAlg.Padding = PaddingMode.Zeros;
    			// Create a decrytor to perform the stream transform.
    			ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
    
    			// Create the streams used for decryption.
    			using (MemoryStream msDecrypt = new MemoryStream(cipherText))
    			{
    				using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
    				{
    					using (StreamReader srDecrypt = new StreamReader(csDecrypt))
    					{
    						// Read the decrypted bytes from the decrypting stream
    						// and place them in a string.
    						plaintext = srDecrypt.ReadToEnd();
    					}
    				}
    			}
    		}		
    		return plaintext;
    	}
    }
