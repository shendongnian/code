    var blobAccount = "<account>";
    var apiKey = "<api-key>";
    var containerName = "<container>";
    var storageCredentials = new StorageCredentials(blobAccount, apiKey);
    var account = new CloudStorageAccount(storageCredentials, true);
    var blobClient = account.CreateCloudBlobClient();
    var container = blobClient.GetContainerReference(containerName);
    var blobLimit = 500
    if (container == null) { return; }
    var blobContinuationToken = new BlobContinuationToken();
    using (var fs = new FileStream("Output.csv", FileMode.Create))
    {
        var sw = new StreamWriter(fs);
        sw.WriteLine("Type,Name,Length");
                
        BlobContinuationToken continuationToken = null;
        do
        {   
            var blobList = container.ListBlobsSegmented("",
                                       true,
                                       BlobListingDetails.Metadata,
                                       blobLimit,
                                       continuationToken,
                                       new BlobRequestOptions
                                       {
                                           LocationMode = LocationMode.PrimaryOnly
                                       },
                                       null);
            continuationToken = blobList.ContinuationToken;
            // I was looking only for BlockBlobs
            foreach (var item in blobList.Results.OfType<CloudBlockBlob>())
            {
                sw.WriteLine($"block,\"{item.Name}\",{item.Properties.Length}");
            }
        } while (continuationToken != null);
    }
