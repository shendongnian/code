	public static string HashString(string StringToHash, string HachKey)
	{
		System.Text.UTF8Encoding myEncoder = new System.Text.UTF8Encoding();
		byte[] Key = myEncoder.GetBytes(HachKey);
		byte[] Text = myEncoder.GetBytes(StringToHash);
		System.Security.Cryptography.HMACSHA1 myHMACSHA1 = new System.Security.Cryptography.HMACSHA1(Key);
		byte[] HashCode = myHMACSHA1.ComputeHash(Text);
		string hash =  BitConverter.ToString(HashCode).Replace("-", "");
		return hash.ToLower();
	}
