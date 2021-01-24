     var connectionString = "xxxxxxxxxxxxxx"; //UseDevelopmentStorage=true
     CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
     CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
     CloudBlobContainer container = blobClient.GetContainerReference("testcontainer");
     container.CreateIfNotExists();
     var sasBlobUri = GetBlobSasUri(container, @"C:\Tom\test.pdf");
     Console.WriteLine(sasBlobUri);
     Console.ReadKey();
     static string GetBlobSasUri(CloudBlobContainer container,string filePath)
     {
    
                if (!container.GetPermissions().PublicAccess.Equals(BlobContainerPublicAccessType.Off))
                {
                    container.SetPermissions(new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Off
                    });
                }
                var blobName = Path.GetFileName(filePath);
                //Get a reference to a blob within the container.
                CloudBlockBlob blob = container.GetBlockBlobReference(blobName);
    
                //Upload text to the blob. If the blob does not yet exist, it will be created.
                //If the blob does exist, its existing content will be overwritten.
                blob.UploadFromFile(filePath);
    
                //Set the expiry time and permissions for the blob.
                //In this case, the start time is specified as a few minutes in the past, to mitigate clock skew.
                //The shared access signature will be valid immediately.
                SharedAccessBlobPolicy sasConstraints =
                    new SharedAccessBlobPolicy
                    {
                        SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5),
                        SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddMinutes(2), // 2 minutes expired
                        Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write  //Read & Write
                    };
    
                //Generate the shared access signature on the blob, setting the constraints directly on the signature.
                string sasBlobToken = blob.GetSharedAccessSignature(sasConstraints);
    
                //Return the URI string for the container, including the SAS token.
                return blob.Uri + sasBlobToken;
        }
