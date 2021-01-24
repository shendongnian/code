    public IEnumerable<string> GetAllBlobNames(string containerName)
    {
        try
        {
            var container = GetOrCreateBlobContainer(containerName);
            var blobs = container.ListBlobs(useFlatBlobListing: true);
            var blobNames = new List<string>();
            foreach (var item in blobs)
            {
                var blob = (CloudBlockBlob)item;
                blob.FetchAttributes();
                blobNames.Add(blob.Name);
            }
            return blobNames;
        }
        catch (Exception ex)
        {
            throw new DomainException("BlobStorageProvider_Retrieve_Fails", typeof(Properties.Resources), containerName, ex.ToStringExtended());
        }
    }
