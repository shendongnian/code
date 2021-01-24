    enum KeyType
    {   
        Customer = 1,
        Administrator = 2,
        Application = 3
    }
    class Encryptor
    {
        static readonly Dictionary<KeyType, string> keyLookup = new Dictinary<KeyType, string>();
        static public Encryptor()
        {
            keyLookup.Add(KeyType.Customer, GetCustomerCryptoKey());
            keyLookup.Add(KeyType.Administrator, GetAdminCryptoKey());
            keyLookup.Add(KeyType.Application, GetApplicationCryptoKey());
        }
        public string Encrypt(KeyType keyType, string input)
        {
            var key = keyLookup[keyType];
            return EncryptInternal(input, key);
        }
    }
    
