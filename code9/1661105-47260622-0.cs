     if (!req.Content.IsMimeMultipartContent())
     {
         return req.CreateResponse(HttpStatusCode.UnsupportedMediaType);
     }
     var storageConnectionString = "connection string";
     var storageAccount = CloudStorageAccount.Parse(storageConnectionString);
     log.Info(storageConnectionString);
     var blobClient = storageAccount.CreateCloudBlobClient();
     CloudBlobContainer container = blobClient.GetContainerReference("temporary-images");
     container.CreateIfNotExists();
     try
     {
        var filesReadToProvider = await req.Content.ReadAsMultipartAsync();
        foreach (var stream in filesReadToProvider.Contents)
        {
           var blobName = stream.Headers.ContentDisposition.FileName.Trim('"');
           CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);          
           blockBlob.UploadFromStream(stream.ReadAsStreamAsync().Result);
      
        }
    
     }
     catch (StorageException e)
     {
            return req.CreateErrorResponse(HttpStatusCode.NotFound, e.Message);
     }
