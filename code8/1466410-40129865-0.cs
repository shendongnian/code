    public class Aes256CbcCryptor : ISymmetricCryptor
    {
        private SymmetricAlgorithm AesProvider { get; }
        public Aes256CbcCryptor(Byte[] key)
        {
            // AesCryptoServiceProvider is not a 'volatile' dependency
            // therefore we don't need to inject it.
            this.AesProvider = 
                new AesCryptoServiceProvider()
                {
                    ...
                    Key = key// This is the real dependency, IMHO
                };
        }
    }
