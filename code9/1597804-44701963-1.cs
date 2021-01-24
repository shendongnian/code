    cmsParser.GetSignedContent().Drain();
    var certStore = cmsParser.GetCertificates("Collection");
    var signerInfos = cmsParser.GetSignerInfos();
    var signers = signerInfos.GetSigners();
    
    foreach (SignerInformation signer in signers)
    {
    	var certCollection = certStore.GetMatches(signer.SignerID);
    	foreach (Org.BouncyCastle.X509.X509Certificate cert in certCollection)
    	{
    		var result = signer.Verify(cert);
    		if (!result)
    		{
    			throw new Exception("Certificate verification error, the signer could not be verified.");
    		}
    	}
    }
