	var randomBytes = new byte[ 32 ];
	using (var rng = new RNGCryptoServiceProvider())
	{
		rng.GetBytes( randomBytes );
	}
	var provider = new SqlColumnEncryptionCertificateStoreProvider();
	var encryptedKey = provider.EncryptColumnEncryptionKey( masterKeyPath, "RSA_OAEP", randomBytes );
	var encryptedKeySerialized = "0x" + BitConverter.ToString( encryptedKey ).Replace( "-", "" );
