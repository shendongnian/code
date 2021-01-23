        public virtual byte[] Key {
            get { 
                if (KeyValue == null) GenerateKey();
                return (byte[]) KeyValue.Clone();
            }
            set { 
                if (value == null) throw new ArgumentNullException("value");
                Contract.EndContractBlock();
                if (!ValidKeySize(value.Length * 8))
                    throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidKeySize"));
                // must convert bytes to bits
                KeyValue = (byte[]) value.Clone(); // your byte[] will be set
                KeySizeValue = value.Length * 8;   // key size will be set too
            }
        }
