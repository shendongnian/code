    //hello : 
    //location of the pdf on the server
    //or
    //bytestream variable with teh pdf loaded in
    //chain: certificate chain
    // we create a reader and a stamper
    PdfReader reader = new PdfReader(hello);
    Stream baos = new MemoryStream();
    PdfStamper stamper = PdfStamper.CreateSignature(reader,  baos., '\0');
    // we create the signature appearance
    PdfSignatureAppearance sap = stamper.SignatureAppearance;
    sap.Reason = "Test";
    sap.Location = "On a server!";
    sap.SetVisibleSignature ( new Rectangle(36, 748, 144, 780), 1, "sig");
    sap.Certificate = chain[0];
    // we create the signature infrastructure
    PdfSignature dic = new PdfSignature(
    PdfName.ADOBE_PPKLITE, PdfName.ADBE_PKCS7_DETACHED);
    dic.Reason = sap.Reason;
    dic.Location = sap.Location;
    dic.Contact = sap.Contact;
    dic.Date = new PdfDate(sap.SignDate);
    sap.CryptoDictionary = dic;
    Dictionary<PdfName, int> exc = new Dictionary<PdfName, int>();
    exc.Add(PdfName.CONTENTS, (int)(8192 * 2 + 2));
    sap.PreClose(exc);
    PdfPKCS7 sgn = new PdfPKCS7(null, chain, "SHA256", false);
    //Extract the bytes that need to be signed
    Stream data = sap.GetRangeStream();
    byte[] hash = DigestAlgorithms.Digest(data,"SHA256");
    byte[] sh = sgn.getAuthenticatedAttributeBytes(hash,null, null, CryptoStandard.CMS);
    //Store sgn, hash,sap and baos on the server
    //...
    //Send sh to client
