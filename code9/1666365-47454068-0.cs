    public long GetBlockBlobSize(string containerName, string blobName)
    {
        try
        {
            CloudBlobContainer container = _blobClient.GetContainerReference(containerName);
            var blockBlob = container.GetBlockBlobReference(blobName);
            blockBlob.FetchAttributes();
            return blockBlob.Properties.Length;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
