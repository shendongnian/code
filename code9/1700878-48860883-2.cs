	public void GenerateRsaCryptoServiceProviderKey()
	{
			var rsaProvider = new RSACryptoServiceProvider(512);
	        SecurityKey key = new RsaSecurityKey(rsaProvider);		
	}
