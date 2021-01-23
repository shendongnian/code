    private string Decrypt(string encrypted)
    {
		byte[] encryptedBytes = Convert.FromBase64String(encrypted);
		string EncryptionKey = "MAKV2SPBNI99212";
		using (Aes encryptor = Aes.Create())
		{
			Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, 
              new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
			encryptor.Key = pdb.GetBytes(32);
			encryptor.IV = pdb.GetBytes(16);
			using (MemoryStream ms = new MemoryStream(encryptedBytes))
			{
				using (CryptoStream cs = new CryptoStream(ms, 
                  encryptor.CreateDecryptor(), CryptoStreamMode.Read))
				{
					MemoryStream buffer = new MemoryStream();
					cs.CopyTo(buffer);
					return Encoding.Unicode.GetString(buffer.ToArray());
				}
			}
		}
	}
