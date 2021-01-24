    using (var inputFile = File.OpenRead(@"E:\Staging\6114d23c-2595abef\testfile.txt.gpg"))
    using (var decoderStream = PgpUtilities.GetDecoderStream(inputFile))
    {
        var objectFactory = new PgpObjectFactory(decoderStream);
        var encryptedList = (PgpEncryptedDataList)objectFactory.NextPgpObject();
        foreach (var encryptedData in encryptedList.GetEncryptedDataObjects().Cast<PgpPublicKeyEncryptedData>())
        {
            var keyId = encryptedData.KeyId.ToString("X");
            Console.WriteLine($"Encryption Key ID: {keyId}");
        }
    }
