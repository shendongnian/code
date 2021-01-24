    private void CreatePfxFile(X509Certificate certificate, AsymmetricKeyParameter privateKey)
	{
		// create certificate entry
		var certEntry = new X509CertificateEntry(certificate);
		string friendlyName = certificate.SubjectDN.ToString();
		// get bytes of private key.
		PrivateKeyInfo keyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKey);
		byte[] keyBytes = keyInfo.ToAsn1Object().GetEncoded();
		var builder = new Pkcs12StoreBuilder();
		builder.SetUseDerEncoding(true);
		var store = builder.Build();
		// create store entry
		store.SetKeyEntry(Core.Constants.PrivateKeyAlias, new AsymmetricKeyEntry(privateKey), new X509CertificateEntry[] { certEntry });
		byte[] pfxBytes = null;
		var password = Guid.NewGuid().ToString("N");
		using (MemoryStream stream = new MemoryStream())
		{
			store.Save(stream, password.ToCharArray(), new SecureRandom());
			pfxBytes = stream.ToArray();
		}
		var result = Pkcs12Utilities.ConvertToDefiniteLength(pfxBytes);
		this.StoreCertificate(Convert.ToBase64String(result));
	}
