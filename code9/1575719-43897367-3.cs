    private static byte[] s_secp384r1PublicPrefix = {
        // SEQUENCE (SubjectPublicKeyInfo, 0x76 bytes)
        0x30, 0x76,
        // SEQUENCE (AlgorithmIdentifier, 0x10 bytes)
        0x30, 0x10,
        // OBJECT IDENTIFIER (id-ecPublicKey)
        0x06, 0x07, 0x2A, 0x86, 0x48, 0xCE, 0x3D, 0x02, 0x01,
        // OBJECT IDENTIFIER (secp384r1)
        0x06, 0x05, 0x2B, 0x81, 0x04, 0x00, 0x22,
        // BIT STRING, 0x61 content bytes, 0 unused bits.
        0x03, 0x62, 0x00,
        // Uncompressed EC point
        0x04,
    }
    ...
    using (ECDiffieHellman ecdh = ECDiffieHellman.Create())
    {
        ecdh.KeySize = 384;
        byte[] prefix = s_secp384r1PublicPrefix;
        byte[] derPublicKey = new byte[120];
        Buffer.BlockCopy(prefix, 0, derPublicKey, 0, prefix.Length);
        byte[] cngBlob = ecdh.PublicKey.ToByteArray();
        Debug.Assert(cngBlob.Length == 104);
        Buffer.BlockCopy(cngBlob, 8, derPublicKey, prefix.Length, cngBlob.Length - 8);
        // Now move it to PEM
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("-----BEGIN PUBLIC KEY-----");
        builder.AppendLine(
            Convert.ToBase64String(derPublicKey, Base64FormattingOptions.InsertLineBreaks));
        builder.AppendLine("-----END PUBLIC KEY-----");
        Console.WriteLine(builder.ToString());
    }
