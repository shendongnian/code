        public static byte[] Sign(
            byte[] pdfIn,
            X509Certificate2 cert,
            string reason = "",
            string hashAlgorithm = DigestAlgorithms.SHA256
            )
        {
            using (var reader = new PdfReader(pdfIn))
            using (var pdfOut = new MemoryStream())
            using (var rsa = (RSACryptoServiceProvider)cert.PrivateKey)
            {
                var stamper = PdfAStamper.CreateSignature(reader, pdfOut, '\0');
                var appearance = stamper.SignatureAppearance;
                appearance.Reason = reason;
                var signature = new PrivateKeySignature(
                    DotNetUtilities.GetRsaKeyPair(rsa).Private,
                    hashAlgorithm);
                var parser = new X509.X509CertificateParser();
                var chain = new X509.X509Certificate[] { 
                parser.ReadCertificate(cert.RawData)
                };
                MakeSignature.SignDetached(
                    appearance,
                    signature,
                    chain,
                    null,
                    null,
                    null,
                    0,
                    CryptoStandard.CADES
                    );
                return pdfOut.ToArray();
            }
        }
