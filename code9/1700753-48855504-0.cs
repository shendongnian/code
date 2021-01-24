    public static bool ValidateSignature(byte[] sha256, string signature)
    {
        if (_asymmetricBlockCipher == null || string.IsNullOrEmpty(signature))
        {
            return false;
        }
        var decoded = Base64.Decode(signature);
        return _asymmetricBlockCipher.ProcessBlock(decoded, 0, decoded.Length).SequenceEqual(sha256);
    }
