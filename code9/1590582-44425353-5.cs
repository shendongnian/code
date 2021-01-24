    public ActionResult Download()
    {
        string blobName = "abc.png";
        string containerName = "mycontainer";
        string connectionString = "";
        // Retrieve storage account from connection string.
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
    
        // Create the blob client.
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
    
        // Retrieve reference to a previously created container.
        CloudBlobContainer container = blobClient.GetContainerReference(containerName);
    
        // Retrieve reference to a blob named "photo1.jpg".
        CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
    
        MemoryStream ms = new MemoryStream();
        // Save blob contents to a file.
        blockBlob.DownloadToStream(ms);
        ms.Position = 0;
    
        return File(ms, "application/octet-stream", blobName);
    }
