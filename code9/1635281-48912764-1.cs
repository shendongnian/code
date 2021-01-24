        public X509Certificate2 CreateCertifacte(string pathToCertificate)
        {
            var keyBytes = File.ReadAllBytes($"{pathToCertificate}/cert.key");
            var certBytes = File.ReadAllBytes($"{pathToCertificate}/cert.crt");
            var certBio = new BIO(certBytes);
            var keyBio = new BIO(keyBytes);
            var key = CryptoKey.FromPrivateKey(keyBio, "_");
            var cert = new X509Certificate(certBio);
            var name = cert.SerialNumber+".pfx";
            var stacks = new Stack<X509Certificate>();
            new X509Store().AddTrusted(cert);
            var certRealPkcs12 = new PKCS12("_", key, cert, stacks);
            using (var file = BIO.File(name, "wb"))
            {
                file.SetClose(BIO.CloseOption.Close); // don't ask me why, i don't know. this one just works.
                certRealPkcs12.Write(file);
            }
            certRealPkcs12.Dispose();
            
            var realCertOut =
                new X509Certificate2(File.ReadAllBytes(name), "_");
            return realCertOut;
        }
