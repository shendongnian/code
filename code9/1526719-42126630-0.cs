    static void TransferBlob(string accountName, string accountKey, string sourceContainerName, string targetContainerName)
    {
        CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
        CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
        CloudBlobContainer sourceContainer = cloudBlobClient.GetContainerReference(sourceContainerName);
        CloudBlobContainer targetContainer = cloudBlobClient.GetContainerReference(targetContainerName);
        if (sourceContainer.Exists() && targetContainer.Exists())
        {
            foreach (IListBlobItem item in sourceContainer.ListBlobs(useFlatBlobListing: true))
            {
                var blob = item as CloudBlockBlob;
                if (blob != null)
                {
                    CloudBlockBlob sourceBlob = sourceContainer.GetBlockBlobReference(blob.Name);
                    CloudBlockBlob targetBlob = targetContainer.GetBlockBlobReference(blob.Name);
                    targetBlob.StartCopy(sourceBlob);
                }
            }
        }
    }
