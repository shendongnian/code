        public static byte[] Sign(byte[] data, X509Certificate2 certificate)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (certificate == null)
                throw new ArgumentNullException("certificate");
            // setup the data to sign
            ContentInfo content = new ContentInfo(data);
            SignedCms signedCms = new SignedCms(content, false);
            CmsSigner signer = new CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, certificate);
            // create the signature
            signedCms.ComputeSignature(signer);
            return signedCms.Encode();
        }
