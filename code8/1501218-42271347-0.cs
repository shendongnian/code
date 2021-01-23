        private static string ComputeSignature()
        {
            AsymmetricCipherKeyPair asymmetricCipherKeyPair;
            using (TextReader textReader = new StreamReader("myprivatekey.pem"))
            {
                asymmetricCipherKeyPair = (AsymmetricCipherKeyPair)new PemReader(textReader).ReadObject();
            }
            DsaPrivateKeyParameters parameters = (DsaPrivateKeyParameters)asymmetricCipherKeyPair.Private;
            string text = TEXTTOENC;
            if (!string.IsNullOrEmpty(userName))
            {
                text += userName;
            }
            Console.Out.WriteLine("Data: {0}", text);
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            DsaDigestSigner dsaDigestSigner = new DsaDigestSigner(new DsaSigner(), new Sha1Digest());
            dsaDigestSigner.Init(true, parameters);
            dsaDigestSigner.BlockUpdate(bytes, 0, bytes.Length);
            byte[] inArray = dsaDigestSigner.GenerateSignature();
            string text2 = Convert.ToBase64String(inArray);
            Console.WriteLine("Signature: {0}", text2);
            return text2;
        }
