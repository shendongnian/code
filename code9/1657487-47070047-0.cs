     public CloudBlobContainer getCloudBlobContainer()
      {
          CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureStorage"].ToString());
          CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
          CloudBlobContainer container = blobClient.GetContainerReference("audiostorage");
          container.CreateIfNotExists(); // remove the if condition
          BlobContainerPermissions permissions = container.GetPermissions();
          permissions.PublicAccess = BlobContainerPublicAccessType.Container;
          container.SetPermissions(permissions);  
          return container;
       }
 
