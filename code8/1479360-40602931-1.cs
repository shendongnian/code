    public class AzureBlobStorageClient
    {
        private CloudBlobClient _cloudBlobClient;
        public AzureBlobStorageClient(IOptions<AzureStorageConfig> config)
        {
            var storageAccount = new CloudStorageAccount(new StorageCredentials(config.Value.AccountName, config.Value.AccountKey), true);
            _cloudBlobClient=storageAccount.CreateCloudBlobClient();
        }
        public async Task<bool> EnsureContainer(string containerName)
        {
            var storageContainer = _cloudBlobClient.GetContainerReference(containerName);
            return await storageContainer.CreateIfNotExistsAsync();
        }
    }
    public class AzureStorageConfig
    {
        public string AccountName { get; set; }
        public string AccountKey { get; set; }
    }
