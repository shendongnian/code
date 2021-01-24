    public class KeyGenerationResult
    {
        public RSAParameters PublicKey { get; set; }
        public string PublicKeyCleartext { get; set; }
        public string PrivateKeyCleartext { get; set; }
        public byte[] PrivateBytes { get; set; }
        public int KeySize { get; set; }
        public CngKeyBlobFormat BlobFormat { get; set; }
    }
        public async Task<KeyGenerationResult> GenerateNewKeyAsync(int keySize)
        {
            var cp = new CngKeyCreationParameters();
            cp.KeyUsage = CngKeyUsages.AllUsages;
            cp.ExportPolicy = CngExportPolicies.AllowPlaintextExport | CngExportPolicies.AllowExport | CngExportPolicies.AllowArchiving | CngExportPolicies.AllowPlaintextArchiving;
            cp.Parameters.Add(new CngProperty("Length", BitConverter.GetBytes(keySize), CngPropertyOptions.None));
            var key = await Task.Run(() => CngKey.Create(CngAlgorithm.Rsa, null, cp)).ConfigureAwait(false);
            var blobType = CngKeyBlobFormat.GenericPrivateBlob;
            var bytes = await Task.Run(() => key.Export(blobType)).ConfigureAwait(false);
            var rsa = new RSACng(key);
            var pubKey = rsa.ExportParameters(includePrivateParameters: false);
            var pubKeyString = exportKeyToString(pubKey);
            return new KeyGenerationResult
            {
                PublicKey = pubKey,
                PrivateKeyCleartext = Convert.ToBase64String(bytes),
                PublicKeyCleartext = pubKeyString,
                PrivateBytes = bytes,
                BlobFormat = blobType,
                KeySize = keySize
            };
        }
        private static string exportKeyToString(RSAParameters key)
        {
            string keyString;
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, key);
            keyString = sw.ToString();
            return keyString;
        }
        public void SavePrivateKeyToLocalMachine(KeyGenerationResult keyData, string keyName)
        {
            var myKSP = CngProvider.MicrosoftSoftwareKeyStorageProvider;
            const bool MachineKey = false;
            if (!CngKey.Exists(keyName, myKSP))
            {
                var keyParams = new CngKeyCreationParameters
                {
                    ExportPolicy = CngExportPolicies.AllowPlaintextExport,
                    KeyCreationOptions = (MachineKey) ? CngKeyCreationOptions.MachineKey : CngKeyCreationOptions.None,
                    Provider = myKSP
                };
                keyParams.Parameters.Add(new CngProperty("Length", BitConverter.GetBytes(keyData.KeySize), CngPropertyOptions.None));
                keyParams.Parameters.Add(new CngProperty(keyData.BlobFormat.Format, keyData.PrivateBytes, CngPropertyOptions.None));
                CngKey.Create(CngAlgorithm.Rsa, keyName, keyParams);
            }
            else
            {
                throw new CryptographicException($"The key with the name '{keyName}' already exists!");
            }
        }
