	private static byte[] SignPublicKey(
	    PgpSecretKey secretKey,
	    string password,
	    PgpPublicKey keyToBeSigned,
        bool isCertain)
	{
		// Extracting private key, and getting ready to create a signature.
		PgpPrivateKey pgpPrivKey = secretKey.ExtractPrivateKey (password.ToCharArray());
		PgpSignatureGenerator sGen = new PgpSignatureGenerator (secretKey.PublicKey.Algorithm, HashAlgorithmTag.Sha1);
        sGen.InitSign (isCertain ? PgpSignature.PositiveCertification : PgpSignature.CasualCertification, pgpPrivKey);
		// Creating a stream to wrap the results of operation.
		Stream os = new MemoryStream();
		BcpgOutputStream bOut = new BcpgOutputStream (os);
		sGen.GenerateOnePassVersion (false).Encode (bOut);
		// Creating a generator.
		PgpSignatureSubpacketGenerator spGen = new PgpSignatureSubpacketGenerator();
		PgpSignatureSubpacketVector packetVector = spGen.Generate();
		sGen.SetHashedSubpackets (packetVector);
		bOut.Flush();
		// Returning the signed public key.
		return PgpPublicKey.AddCertification (keyToBeSigned, sGen.Generate()).GetEncoded();
	}
