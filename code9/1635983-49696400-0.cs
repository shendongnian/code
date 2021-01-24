     [TestMethod]
     public void TestDelaySigning()
     {
                const string hashAlgorithm = "SHA256";
                const string signAlgorithm = "ECDSA"; // or "RSA" 
                bool isRsa =false; // or true for RSA
    
               // Create CSR
                var signatureAlgorithm = hashAlgorithm + "with" + signAlgorithm; // "SHA256withECDSA" or "SHA256withRSA"
                byte[] octetData = CreateCsr(keys.SignKeyPair, signatureAlgorithm);
                byte[] csrWithPass = AppendPassword(octetData, "some-password");
    
                byte[] hash = BuildHash(csrWithPass, hashAlgorithm);
    
                // Sign the hash
                string singingAlgorithm2 = "NONEwith" + signAlgorithm;
                byte[] signature = Sign(hash, singingAlgorithm2, hashAlgorithm, keys.SignKeyPair.Private, isRsa );
    
                byte[] csrSigned = AppendSignature(csrWithPass, signature);
    
                Verify(csrSigned);
     }
    
            public byte[] BuildHash(byte[] csr, string algorithm)
            {
                var originalCsr = new Pkcs10CertificationRequestDelaySigned(csr);
                byte[] dataToSign = originalCsr.GetDataToSign();
                byte[] digest = DigestUtilities.CalculateDigest(algorithm, dataToSign);
                return digest;
            }
    
            public static byte[] Sign(byte[] hash, string signerAlgorithm, string hashAlgorithm, 
                                                         AsymmetricKeyParameter privateSigningKey, bool isRsa)
            {
                if (isRsa)
            {
                var hashAlgorithmOid = DigestUtilities.GetObjectIdentifier(hashAlgorithm).Id;
                var digestAlgorithm = new AlgorithmIdentifier(new DerObjectIdentifier(hashAlgorithmOid), DerNull.Instance);
                var dInfo = new DigestInfo(digestAlgorithm, hash);
                byte[] digest = dInfo.GetDerEncoded();
                hash = digest;
            }
            
            ISigner signer = SignerUtilities.GetSigner(signerAlgorithm);
            signer.Init(true, privateSigningKey);
            signer.BlockUpdate(hash, 0, hash.Length);
            byte[] signature = signer.GenerateSignature();
            return signature;
          }
     }
