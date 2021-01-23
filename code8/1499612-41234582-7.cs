        string storageConnectionString = "storage connection string";
        CloudStorageAccount account = CloudStorageAccount.Parse(storageConnectionString);
        CloudBlobClient blobClient = account.CreateCloudBlobClient();
        CloudBlobContainer blobContainer = blobClient.GetContainerReference("mycontainer");
        blobContainer.CreateIfNotExists();
        string sourcePath = @"C:\Tom\TestLargeFile.zip";
        CloudBlockBlob destBlob = blobContainer.GetBlockBlobReference("LargeFile.zip");
        // Setup the number of the concurrent operations
        TransferManager.Configurations.ParallelOperations = 64;
        // Setup the transfer context and track the upoload progress
    
        var context = new SingleTransferContext();
    
        UploadOptions uploadOptions = new UploadOptions
        {
            DestinationAccessCondition = AccessCondition.GenerateIfExistsCondition()
        };
        context.ProgressHandler = new Progress<TransferStatus>(progress =>
        {
            Console.WriteLine("Bytes uploaded: {0}", progress.BytesTransferred);
        });
        // Upload a local blob
        TransferManager.UploadAsync(sourcePath, destBlob, uploadOptions,context, CancellationToken.None).Wait();
 
