    var keyData = Encoding.ASCII.GetBytes("{2B9B4443-74CE-42A8-8803-076B136B5967}");
    byte[] key;
    using (PasswordDeriveBytes pdb = new PasswordDeriveBytes(keyData, null))
    {
        key = pdb.CryptDeriveKey("TripleDES", "MD5", 0, new byte[8]);
        //Debug.WriteLine(BitConverter.ToString(key));
    }
    using (var prov = new TripleDESCryptoServiceProvider())
    {
        using (var encryptor = prov.CreateEncryptor(key, new byte[8]))
        {
            byte[] encrypted = encryptor.TransformFinalBlock(bytes2, 0, bytes2.Length);
            //Debug.WriteLine(BitConverter.ToString(encrypted));
        }
    }
