                string storageConnectionString = "myStorageConnectionString";
                CloudStorageAccount account = CloudStorageAccount.Parse(storageConnectionString);
                CloudBlobClient blobClient = account.CreateCloudBlobClient();
                CloudBlobContainer blobContainer = blobClient.GetContainerReference("mycontainer");
                blobContainer.CreateIfNotExistsAsync().Wait();
                string sourcePath = @"C:\Tom\TestLargeFile.zip";
                CloudBlockBlob destBlob = blobContainer.GetBlockBlobReference("LargeFile.zip");
                // Setup the number of the concurrent operations
                TransferManager.Configurations.ParallelOperations = 64;
                // Setup the transfer context and track the upoload progress
                var context = new SingleTransferContext
                {
                    ProgressHandler =
                    new Progress<TransferStatus>(
                       progress => { Console.WriteLine("Bytes uploaded: {0}", progress.BytesTransferred); })
                };
                // Upload a local blob
                TransferManager.UploadAsync(sourcePath, destBlob, null, context, CancellationToken.None).Wait();
                Console.WriteLine("Upload finished !");
                Console.ReadKey();
