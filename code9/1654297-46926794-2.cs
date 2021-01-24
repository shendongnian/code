    public bool UploadBlobFile(string containerName, string blobName, string filePath)
    {
        try{
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            CloudBlockBlob blob = container.GetBlockBlobReference(blobName);
            // convert dos2unix format
            Dos2Unix(filePath);
            using (var fileStream = System.IO.File.OpenRead(filePath))
            {
                blob.UploadFromStream(fileStream);
            }
            return true;
        } catch (Exception e) {
            log.Info("Exception: " + e);
            return false;
        }
    }
