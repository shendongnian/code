      private static bool VerifySignatures(FileInfo contentFile, Stream signedDataStream)
        {
            CmsProcessable signedContent = null;
            CmsSignedData cmsSignedData = null;
            Org.BouncyCastle.X509.Store.IX509Store store = null;
            ICollection signers = null;
            bool verifiedStatus = false;
            try
            {
                //Org.BouncyCastle.Security.addProvider(new BouncyCastleProvider());
                signedContent = new CmsProcessableFile(contentFile);
                cmsSignedData = new CmsSignedData(signedContent, signedDataStream);
                store = cmsSignedData.GetCertificates("Collection");//.getCertificates();
                IX509Store certStore = cmsSignedData.GetCertificates("Collection");
                signers = cmsSignedData.GetSignerInfos().GetSigners();
                foreach (var item in signers)
                {
                    SignerInformation signer = (SignerInformation)item;
                    var certCollection = certStore.GetMatches(signer.SignerID);
                    IEnumerator iter = certCollection.GetEnumerator();
                    iter.MoveNext();
                    var cert = (Org.BouncyCastle.X509.X509Certificate)iter.Current;
                    verifiedStatus = signer.Verify(cert.GetPublicKey());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return verifiedStatus;
        }
