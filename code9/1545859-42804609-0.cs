    public string GetBlobSasUri(string containerName, string blobName, string connectionstring)
    {
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstring);
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        var container = blobClient.GetContainerReference(containerName);
        CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
        //Set the expiry time and permissions for the blob.
        //In this case no start time is specified, so the shared access signature becomes valid immediately.
        SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
        sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(10);
        sasConstraints.Permissions = SharedAccessBlobPermissions.Read;
        //Generate the shared access signature on the blob, setting the constraints directly on the signature.
        string sasContainerToken = blockBlob.GetSharedAccessSignature(sasConstraints);
        //Return the URI string for the blob, including the SAS token.
        return blockBlob.Uri + sasContainerToken;
    }
