     public async Task UploadBlobAsync()
            {
                const string myconnctionstring = "DefaultEndpointsProtocol=https;AccountName=accountname;AccountKey=yourkey;EndpointSuffix=core.windows.net";
                //var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(myconnctionstring);
    
                // Create the blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
    
                // Retrieve reference to a previously created container.
                CloudBlobContainer container = blobClient.GetContainerReference("test");
    
                container.CreateIfNotExistsAsync().Wait();
                // Retrieve reference to a blob named "test".
                CloudBlockBlob blockBlob = container.GetBlockBlobReference("test.jpg");
    
                // Create or overwrite the "test" blob with contents from a local file.
                using (var fileStream = System.IO.File.OpenRead(@"file path"))
                {
                    await blockBlob.UploadFromStreamAsync(fileStream);
                }
            }
