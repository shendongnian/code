    // Retrieve storage account from connection string.
    CloudStorageAccount storageAccount = CloudStorageAccount.Parse("storage connection string");
    
    // Create the blob client.
    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
    
    string containerName = "mycontainer";
    
    // Retrieve reference to a previously created container.
    CloudBlobContainer container = blobClient.GetContainerReference(containerName);
    
    var blobs = container.ListBlobs(string.Empty, true);
    string currentDateTime = DateTime.Now.ToString("yyyyMMddhhmmss");
    string directoryPath = Server.MapPath("~/Content/" + containerName + currentDateTime);
    System.IO.Directory.CreateDirectory(directoryPath);
    foreach (CloudBlockBlob blockBlob in blobs)
    {
        string[] segements = blockBlob.Name.Split('/');
        string subFolderPath = directoryPath;
        for (int i = 0; i < segements.Length - 1; i++)
        {
            subFolderPath = subFolderPath + "\\" + segements[i];
            if (!System.IO.Directory.Exists(subFolderPath))
            {
                System.IO.Directory.CreateDirectory(subFolderPath);
            }
        }
        string filePath = directoryPath + "\\" + blockBlob.Name;
        blockBlob.DownloadToFile(filePath, System.IO.FileMode.CreateNew);
    }
    
    Console.WriteLine("Download files successful.");
