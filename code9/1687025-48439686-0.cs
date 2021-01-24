    public class iTransactVerifier
    {
        private const string PublicKey = @"-----BEGIN PGP PUBLIC KEY BLOCK-----
    Version: 4.5
     
    mQCNAjZu
    -----END PGP PUBLIC KEY BLOCK-----";
        public static bool Verify(string signature, string data)
        {
            var inputStream = ConvertStringToStream(signature);
            PgpPublicKey publicKey = ReadPublicKeyFromString();
            var stream = PgpUtilities.GetDecoderStream(inputStream);
            PgpObjectFactory pgpFact = new PgpObjectFactory(stream);
            
            PgpSignatureList sList = pgpFact.NextPgpObject() as PgpSignatureList;
            if (sList == null)
            {
                throw new InvalidOperationException("PgpObjectFactory could not create signature list");
            }
            PgpSignature firstSig = sList[0];
            firstSig.InitVerify(publicKey);
            firstSig.Update(Encoding.UTF8.GetBytes(data));
            
            var verified = firstSig.Verify();
            return verified;
        }
		....
		
        private static PgpPublicKey ReadPublicKeyFromString()
        {
            var varstream = ConvertStringToStream(PublicKey);
            var stream = PgpUtilities.GetDecoderStream(varstream);
            PgpObjectFactory pgpFact = new PgpObjectFactory(stream);
            var keyRing = (PgpPublicKeyRing)pgpFact.NextPgpObject();
            return keyRing.GetPublicKey();
        }
    }
