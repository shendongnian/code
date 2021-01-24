    public int Main()
    {
         string initialkey = NewEncryptionClass.Key;
         string result1 = new EncryptionClass().Encrypt("encryptThis"); // using key1
         // let's change the key
         string result2 = new EncryptionClass("key2").Encrypt("encryptThat"); // using key2
         string result3 = new EncryptionClass().Encrypt("encryptOther"); // still using key2
    }
