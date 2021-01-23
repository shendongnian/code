    public class SignDocsProvider : ISignDocsProvider
    {
        public string GenerateSignature(string privateKey, string password, string documentId)
        {
            var keyPair = ReadPrivateKey(privateKey, password);
            var sha1Digest = new Sha1Digest();
            var rsaDigestSigner = new RsaDigestSigner(sha1Digest);
            rsaDigestSigner.Init(true, keyPair);
            var documentIdToSign = Encoding.ASCII.GetBytes(documentId);
            rsaDigestSigner.BlockUpdate(documentIdToSign, 0, documentIdToSign.Length);
            return Convert.ToBase64String(rsaDigestSigner.GenerateSignature());
        }
        private static AsymmetricKeyParameter ReadPrivateKey(string privateKey, string password)
        {
            AsymmetricCipherKeyPair keyPair;
            using (var reader = new StringReader(privateKey))
                keyPair = (AsymmetricCipherKeyPair)new PemReader(reader, new PasswordFinder(password)).ReadObject();
            return keyPair.Private;
        }
    }
    internal class PasswordFinder : IPasswordFinder
    {
        private readonly string _password;
        public PasswordFinder(string password)
        {
            _password = password;
        }
        public char[] GetPassword()
        {
            return _password.ToCharArray();
        }
    }
