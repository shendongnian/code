    // Add DataProtection Service
    if (storageUrl != null && sasToken != null && containerName != null && applicationName != null && blobName != null)
    {
        // Create the new Storage URI
        Uri storageUri = new Uri($"{storageUrl}{sasToken}");
    
        //Create the blob client object.
        CloudBlobClient blobClient = new CloudBlobClient(storageUri);
    
        //Get a reference to a container to use for the sample code, and create it if it does not exist.
        CloudBlobContainer container = blobClient.GetContainerReference(containerName);
        container.CreateIfNotExists();
    
        services.AddDataProtection()
            .SetApplicationName(applicationName)
            .PersistKeysToAzureBlobStorage(container, blobName);
    }
    
    // Add framework services.
    services.AddMvc();
