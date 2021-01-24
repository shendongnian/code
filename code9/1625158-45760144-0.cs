    public class HMACFnv1_32 : HMAC
    {
        private const string Fnv1CryptoConfigId = "Fnv1_32";
        static HMACFnv1_32()
        {
            CryptoConfig.AddAlgorithm(typeof(Fnv1_32), Fnv1CryptoConfigId);
        }
        public HMACFnv1_32(byte[] key)
        {
            HashName = Fnv1CryptoConfigId;
            HashSizeValue = 32;
            InitializeKey(key);
        }
    }
