    private static bool CheckValidPassword(string password)
	{
		//from sf_users column [salt]
		var userSalt = "420540B274162AA093FDAC86894F3172";
		//from sf_users column [passwd]
		var userPassword = "a99j8I0em8DOP1IAJO/O7umQ+H0=";
		//from App_Data\Sitefinity\Configuration\SecurityConfig.config attribute "validationKey"
		var validationKey = "862391D1B281951D5D92837F4DB9714E0A5630F96483FF39E4307AE733424C557354AE85FF1C00D73AEB48DF3421DD159F6BFA165FF8E812341611BDE60E0D4A";
		return userPassword == ComputeHash(password + userSalt, validationKey);
	}
	internal static string ComputeHash(string data, string key)
	{
		byte[] hashKey = HexToBytes(key);
		HMACSHA1 hmacshA1 = new HMACSHA1();
		hmacshA1.Key = hashKey;
		var hash = hmacshA1.ComputeHash(Encoding.Unicode.GetBytes(data));
		return Convert.ToBase64String(hash);
	}
	public static byte[] HexToBytes(string hexString)
	{
		byte[] numArray = new byte[hexString.Length / 2];
		for (int index = 0; index < numArray.Length; ++index)
			numArray[index] = Convert.ToByte(hexString.Substring(index * 2, 2), 16);
		return numArray;
	}
