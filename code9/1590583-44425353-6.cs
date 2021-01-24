    public ActionResult Download()
    {
        string blobName = "abc.png";
        string containerName = "mycontainer";
        string connectionString = "";
    
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
        var sasConstraints = new SharedAccessBlobPolicy();
        sasConstraints.SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-5);
        sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(10);
        sasConstraints.Permissions = SharedAccessBlobPermissions.Read;
    
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference(containerName);
        CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
    
        var sasBlobToken = blockBlob.GetSharedAccessSignature(sasConstraints);
    
        var sasUrl = blockBlob.Uri + sasBlobToken;
    
        return Redirect(sasUrl);
    }
