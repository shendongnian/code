     [TestMethod]
        public void TestEnvelopedCMS()
        {
            X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
            X509Certificate2Collection fcollection = (X509Certificate2Collection)collection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
      
            byte[] data = new byte[256];
            //lets change data before we encrypt
            data[2] = 1;
            ContentInfo contentInfo = new ContentInfo(data);
            EnvelopedCms envelopedCms = new EnvelopedCms(contentInfo, new AlgorithmIdentifier(new System.Security.Cryptography.Oid("2.16.840.1.101.3.4.1.42")));
            CmsRecipientCollection recipients = new CmsRecipientCollection(SubjectIdentifierType.IssuerAndSerialNumber, fcollection);
            envelopedCms.Encrypt(recipients);
            byte[] encryptedData = envelopedCms.Encode();
            //lets decrypt now
            envelopedCms.Decode(encryptedData);
            envelopedCms.Decrypt(fcollection);
            byte[] decryptedData = envelopedCms.ContentInfo.Content;
            Assert.IsTrue(decryptedData == data);
        }
