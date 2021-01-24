    public XmlElement EncryptXml(XmlElement assertion, X509Certificate2 cert)
        {
            //cert = new X509Certificate2(@"C:\temp\SEI.cer");
            XmlElement returnElement;
            EncryptedData message = new EncryptedData();
            message.Type = "http://www.w3.org/2001/04/xmlenc#Element";
            message.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES256KeyWrapUrl);
            //message.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES128KeyWrapUrl);
            EncryptedKey key = new EncryptedKey();
            key.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url);
            key.KeyInfo.AddClause(new KeyInfoX509Data(cert));
        
            var rKey = new RijndaelManaged();
            rKey.BlockSize = 128;
            rKey.KeySize = 128;
            rKey.Padding = PaddingMode.PKCS7;
            rKey.Mode = CipherMode.CBC;
        
            key.CipherData.CipherValue = EncryptedXml.EncryptKey(rKey.Key, (RSA)cert.PublicKey.Key, false);
            KeyInfoEncryptedKey keyInfo = new KeyInfoEncryptedKey(key);
            message.KeyInfo.AddClause(keyInfo);
        
            message.CipherData.CipherValue = new EncryptedXml().EncryptData(assertion, rKey, false);
            returnElement = message.GetXml();
        
            Logger("Cert Size: " + System.Text.ASCIIEncoding.Unicode.GetByteCount(cert.ToString()));
        
            GetBytesKeyAndData(rKey, assertion.InnerText);
        
        
            return returnElement;
        }
