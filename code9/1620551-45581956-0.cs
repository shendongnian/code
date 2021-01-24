    var connectionString = "UseDevelopmentStorage=true";
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("testcontainer");
            container.CreateIfNotExists();
            var sasBlobUri = GetBlobSasUri(container, @"C:\Tom\test.pdf");
      
      container.SetPermissions(new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Off //private
                    });
