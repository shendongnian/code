    // Define a selector matching issuer and serial number
    X509CertStoreSelector selector = new X509CertStoreSelector();
    selector.Issuer = tts.SignerID.Issuer;
    selector.SerialNumber = tts.SignerID.SerialNumber;
    // Retrieve the matching certificates from the time stamp certificate collection
    System.Collections.ICollection certs = tts.GetCertificates("COLLECTION").GetMatches(selector);
    // Assuming at most one match, retrieve this matching certificate
    IEnumerator enumCerts = certs.GetEnumerator();
    if (enumCerts.MoveNext())
    {
        X509Certificate cert = (X509Certificate)enumCerts.Current;
        // Verify that this is the correct certificate by verifying the time stamp token
        tts.Validate(cert);
        // Extracting information from the now verified tsa certificate
        Console.WriteLine(String.Format("Not before: {0}", cert.NotBefore));
        Console.WriteLine(String.Format("Not after: {0}", cert.NotAfter));
    }
