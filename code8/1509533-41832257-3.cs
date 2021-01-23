    // Check if the signature is valid
    if (issuerCert != null) {
	    signCert.Verify(issuerCert.GetPublicKey());
    }
    // Also in case, the certificate is self-signed
    else {
	    signCert.Verify(signCert.GetPublicKey());
    } 
