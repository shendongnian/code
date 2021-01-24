     public byte[] SignMsg(string hexhash)
        {
            byte[] hash = hexToByteArray(hexhash);
            Pkcs12Store store = new Pkcs12Store(getCertificate(), "*********".ToCharArray());
            String alias = "";
            foreach (string al in store.Aliases)
                if (store.IsKeyEntry(al) && store.GetKey(al).Key.IsPrivate)
                {
                    alias = al;
                    break;
                }
            AsymmetricKeyEntry pk = store.GetKey(alias);
            X509CertificateEntry[] chain = store.GetCertificateChain(alias);
            List<Org.BouncyCastle.X509.X509Certificate> c = new List<Org.BouncyCastle.X509.X509Certificate>();
            foreach (X509CertificateEntry en in chain)
            {
                c.Add(en.Certificate);
            }
            PrivateKeySignature signature = new PrivateKeySignature(pk.Key, "SHA256");
            String hashAlgorithm = signature.GetHashAlgorithm();
            PdfPKCS7 sgn = new PdfPKCS7(null, c, hashAlgorithm, false);
            DateTime signingTime = DateTime.Now;
            byte[] sh = sgn.getAuthenticatedAttributeBytes(hash, null, null, CryptoStandard.CMS);
            byte[] extSignature = signature.Sign(sh);
            sgn.SetExternalDigest(extSignature, null, signature.GetEncryptionAlgorithm());
            return sgn.GetEncodedPKCS7(hash, null, null, null, CryptoStandard.CMS);
    
        }
