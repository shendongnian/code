        byte[] em;
        // ECIES uses AES with the all zero IV. Since the key is never reused,
        // there's not risk in that.
        using (Aes aes = Aes.Create())
        using (ICryptoTransform encryptor = aes.CreateEncryptor(ek, new byte[16]))
        {
            if (!encryptor.CanTransformMultipleBlocks)
            {
                throw new InvalidOperationException();
            }
            em = encryptor.TransformFinalBlock(message, 0, message.Length);
        }
