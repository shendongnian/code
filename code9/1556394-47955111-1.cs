    if (bytesCypherText.Length * 8 < objRsaCrypto.KeySize)
    {
        byte[] tmp = new byte[objRsaCrypto.KeySize / 8];
        Buffer.BlockCopy(
            bytesCypherText,
            0,
            tmp,
            tmp.Length - bytesCypherText.Length,
            bytesCypherText.Length);
        bytesCypherText = tmp;
    }
    byte[] bytesPlainTextData = objRsaCrypto.Decrypt(bytesCypherText, false);
