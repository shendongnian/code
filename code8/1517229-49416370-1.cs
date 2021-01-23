    const string rsaOid = "1.2.840.113549.1.1.1";
    Oid oid = new Oid(rsaOid);
    AsnEncodedData keyValue = new AsnEncodedData(publicKeyBytes);           // see question
    AsnEncodedData keyParam = new AsnEncodedData(new byte[] { 05, 00 });    // ASN.1 code for NULL
    PublicKey pubKeyRdr = new PublicKey(oid, keyParam, keyValue);
    var rsaCryptoServiceProvider = (RSACryptoServiceProvider)pubKeyRdr.Key;
