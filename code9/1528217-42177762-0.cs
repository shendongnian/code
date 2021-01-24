    const string CryptLib::EncryptRSA(const string& plaintext, const string& publicKey)
    {
        //Decode public key
        RSA::PublicKey pbKeyDecoded;
        StringSource ss2(publicKey, true, new Base64Decoder);
        pbKeyDecoded.BERDecode(ss2);
 
        Integer m = Integer((const byte*)plaintext.data(), plaintext.size());
        Integer crypted = pbKeyDecoded.ApplyFunction(m);
        ...
    }
