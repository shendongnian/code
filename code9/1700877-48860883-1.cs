	public void GenerateRsaCryptoServiceProviderKey()
	{
		var rsaProvider = new RSACryptoServiceProvider(512);	// Provide key length
		var	PrivateKey = Convert.ToBase64String(rsaProvider.ExportCspBlob(true));
		var	PublicKey = Convert.ToBase64String(rsaProvider.ExportCspBlob(false));		
	}
