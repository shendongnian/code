	string tmp = "test";
	byte[] bTmp = System.Text.Encoding.UTF8.GetBytes(tmp);
	byte[] hashed = null;
	using (System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider())
	{
		hashed = md5.ComputeHash(bTmp);
	}
	
	Console.WriteLine(Convert.ToBase64String(hashed));
