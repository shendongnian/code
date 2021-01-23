    const string rsaOid = "1.2.840.113549.1.1.1";
    Oid oid = new Oid(rsaOid);
    AsnEncodedData keyValue = new AsnEncodedData(data);
    AsnEncodedData keyParam = new AsnEncodedData(new byte[] { 05, 00 });    //asn.1 code for NULL
    PublicKey pubKeyRdr = new PublicKey(oid, keyParam, keyValue);
    var rsaCryptoServiceProvider = (RSACryptoServiceProvider)pubKeyRdr.Key;
