    protected byte[] RestoreSymmertricKey(byte[] sharedSecretBytes)
    {
        byte[] merchantIdentifier = ExtractMIdentifier();
        ConcatenationKdfGenerator generator = new ConcatenationKdfGenerator(new Sha256Digest());
        byte[] algorithmIdBytes = Encoding.UTF8.GetBytes((char)0x0d + "id-aes256-GCM");
        byte[] partyUInfoBytes = Encoding.UTF8.GetBytes("Apple");
        byte[] partyVInfoBytes = merchantIdentifier;
        byte[] otherInfoBytes = Combine(Combine(algorithmIdBytes, partyUInfoBytes), partyVInfoBytes);
        generator.Init(new KdfParameters(sharedSecretBytes, otherInfoBytes));
        byte[] encryptionKeyBytes = new byte[32];
        generator.GenerateBytes(encryptionKeyBytes, 0, encryptionKeyBytes.Length);
        return encryptionKeyBytes;
    }
