	public string EncodeSignStringForSharedKey(string stringToSign, string accountKey)
	{
		HMACSHA256 h = new HMACSHA256(Convert.FromBase64String(accountKey));
		var byteArray = h.ComputeHash(Encoding.UTF8.GetBytes(stringToSign));
		string signature = Convert.ToBase64String(byteArray);
		return signature;
	}
