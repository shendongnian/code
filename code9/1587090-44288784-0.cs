    byte[] key = new byte[3219];
    byte[] text = new byte[to_decrypt.Length - key.Length];
    Buffer.BlockCopy(to_decrypt, 0, key, 0, key.Length);
    Buffer.BlockCopy(to_decrypt, key.Length, text, 0, text.Length);
    ...
    string skey = System.Text.Encoding.UTF8.GetString(key, 0, key.Length);
