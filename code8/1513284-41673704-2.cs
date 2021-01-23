    CloudStorageAccount storageAccount = CloudStorageAccount.Parse("You connection string");
 
    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
 
    CloudBlobContainer container = blobClient.GetContainerReference("testcont"); //your container name
 
    CloudBlockBlob blockBlob = container.GetBlockBlobReference("test.zip"); //blob name
 
    using (var memoryStream = new MemoryStream())
    {
          blockBlob.DownloadToStream(memoryStream);
          using (ZipArchive zip = new ZipArchive(memoryStream))
          {
              var count = zip.Entries.Count;
          }
          // Todo list   we can use CloudBlockBlob.StartCopy to copy blob to another storage  
    }
  
