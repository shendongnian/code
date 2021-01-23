         //StorageConnectionString string specified in configuration file
           CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("StorageConnectionString"));
            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            // Retrieve a reference to a container.
            //specified container name
            CloudBlobContainer container = blobClient.GetContainerReference("myBlobcontainer");
            // Create the container if it doesn't already exist.
            container.CreateIfNotExists();
            container.SetPermissions(
            new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("myBlob");
            // Create or overwrite the "myblob" blob with contents from a local file.
          using (var fileStream = file.InputStream)
            {
                blockBlob.UploadFromStream(fileStream);
            }
