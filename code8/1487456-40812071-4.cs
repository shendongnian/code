    public virtual int KeySize {
        get { return KeySizeValue; }
        set {
            if (!ValidKeySize(value))
                throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidKeySize"));
            KeySizeValue = value;
            KeyValue = null; // here keyvalue becomes null
        }
    }
