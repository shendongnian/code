	public string Encrypt(string secret, string unprotectedText)
	{
		using (var conn = new SqlConnection(...))
		{
			var x = conn.ExecuteScalar(@"SELECT ENCRYPTBYPASSPHRASE(@secret, @text)",
				new { secret, text });
			return ByteArrayToString((byte[])x);
		}
	}
	public string Decrypt(string secret, string ciphertext)
	{
		using (var conn = new SqlConnection(...))
		{
			return conn.ExecuteScalar(@"SELECT CONVERT(NVARCHAR(4000), DECRYPTBYPASSPHRASE(@secret, @ciphertext))", 
				new { secret, ciphertext = StringToByteArray(ciphertext) }).ToString();
		}
	}
