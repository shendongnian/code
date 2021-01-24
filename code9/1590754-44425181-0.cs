    private IDictionary<string, string> UnencryptMyConfiguration()
    {
        EncryptIfNotEncrypted();
        var configFileBytes = File.ReadAllBytes(_filePath);
        var decryptedData = _privKey.Decrypt(configFileBytes, RSAEncryptionPadding.Pkcs1);
        var jsonString = Encoding.UTF8.GetString(decryptedData);
        //treat the decrypted string as a Stream to let JsonConfigurationFileParser handle it
        using (MemoryStream stream = new MemoryStream())
        {
            var parser = new JsonConfigurationFileParser();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(jsonString);
            writer.Flush();
            stream.Position = 0;
            return parser.Parse(stream);
        };
    }
