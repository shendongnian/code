    public class CustomSignedXml: SignedXml
        {
        public CustomSignedXml(XmlDocument xmlDoc):base(xmlDoc)
        {
        }
        internal void ComputeSignature(ISignerProvider signerProvider)
        {
            var methodInfo = typeof (SignedXml).GetMethod("BuildDigestedReferences",
                BindingFlags.Instance | BindingFlags.NonPublic);
            methodInfo.Invoke(this, null);
            SignedInfo.SignatureMethod = XmlDsigRSASHA1Url;
            // See if there is a signature description class defined in the Config file
            SignatureDescription signatureDescription =
                CryptoConfig.CreateFromName(SignedInfo.SignatureMethod) as SignatureDescription;
            if (signatureDescription == null)
                throw new CryptographicException("Cryptography_Xml_SignatureDescriptionNotCreated");
    
            var hashAlg = signatureDescription.CreateDigest();
            if (hashAlg == null)
                throw new CryptographicException("Cryptography_Xml_CreateHashAlgorithmFailed");
            var methodInfo2 = typeof (SignedXml).GetMethod("GetC14NDigest", BindingFlags.Instance | BindingFlags.NonPublic);
            var hashvalue = (byte[]) methodInfo2.Invoke(this, new object[] {hashAlg});
            
            m_signature.SignatureValue = signerProvider.Sign(hashvalue);
        }
    }
