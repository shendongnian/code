                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("connection string");
                var blobClient = storageAccount.CreateCloudBlobClient();
                var container =blobClient.GetContainerReference("container name");
                var blobList = container.ListBlobs();
    
                var tomIndexsList = blobList.Select(blob => new TomTestModel
                {
                    fileId = Guid.NewGuid().ToString(), blobURL = blob.Uri.ToString(), fileText = "Blob Content", keyPhrases = "key phrases",
                }).ToList();
                var batch = IndexBatch.Upload(tomIndexsList);
                ISearchIndexClient indexClient = serviceClient.Indexes.GetClient("index");
                indexClient.Documents.Index(batch);
