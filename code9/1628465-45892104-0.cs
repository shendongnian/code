    public static string Encrypt(string plainText, string passPhrase)
    	{
    		byte[] initVectorBytes = Encoding.UTF8.GetBytes("pemgail9uzpgzl88");
    		byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
    		PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
    		byte[] keyBytes = password.GetBytes(256 / 8);
    		RijndaelManaged symmetricKey = new RijndaelManaged();
    		symmetricKey.Mode = CipherMode.CBC;
    		symmetricKey.Padding = PaddingMode.PKCS7;
    		ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
    		MemoryStream memoryStream = new MemoryStream();
    		CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
    		cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
    		cryptoStream.FlushFinalBlock();
    		byte[] cipherTextBytes = memoryStream.ToArray();
    		memoryStream.Close();
    		cryptoStream.Close();
    		string cipherText = Convert.ToBase64String(cipherTextBytes);
    		return cipherText;
    	}
    
    	public static string Decrypt(string cipherText, string passPhrase)
    	{
    		byte[] initVectorBytes = Encoding.UTF8.GetBytes("pemgail9uzpgzl88");
    		byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
    		PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
    		byte[] keyBytes = password.GetBytes(256 / 8);
    		RijndaelManaged symmetricKey = new RijndaelManaged();
    		symmetricKey.Mode = CipherMode.CBC;
    		symmetricKey.Padding = PaddingMode.PKCS7;
    		ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
    		MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
    		CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
    		byte[] plainTextBytes = new byte[cipherTextBytes.Length];
    		int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
    		memoryStream.Close();
    		cryptoStream.Close();
    		string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
    		return plainText;
    	}
