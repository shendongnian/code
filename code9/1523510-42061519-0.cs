    System.Security.Cryptography.RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
    rsa.FromXmlString(xmlPrivatelKey);
    byte[] data1 = rsa.ExportCspBlob(false);
    byte[] data2 = rsa.ExportCspBlob(true);
    string pubkey = System.Convert.ToBase64String(data1);
    string privKey = System.Convert.ToBase64String(data2);
