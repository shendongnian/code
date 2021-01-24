    public async Task<IActionResult> UploadFileToNewsAsync(IFormFile files, AdminViewModel model)
            {
                var name = UrlFriendlySEO.Url(model.NameValue);//make this name SEO friendly here.
                var filename = name + png;           
                CloudStorageAccount storageAccount = new CloudStorageAccount(new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(Accountname, KeyValue), true);
                // Create the blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
    
                // Retrieve a reference to a container.
                CloudBlobContainer container = blobClient.GetContainerReference(ContainerValue);
    
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(filename);
                using (var f = System.IO.File.OpenRead(files.FileName))
                {
                    await blockBlob.UploadFromStreamAsync(f);
                }
                return View();
           }
