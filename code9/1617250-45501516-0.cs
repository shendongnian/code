    public ActionResult DownloadImage()
    {
        try
        {
            var filename = "xxx.PNG";
            var storageAccount = CloudStorageAccount.Parse("{connection_string}");
            var blobClient = storageAccount.CreateCloudBlobClient();
    
            CloudBlobContainer container = blobClient.GetContainerReference("mycontainer");
            CloudBlockBlob blob = container.GetBlockBlobReference(filename);
    
            Stream blobStream = blob.OpenRead();
    
            return File(blobStream, blob.Properties.ContentType, filename);
    
        }
        catch (Exception)
        {
            //download failed 
            //handle exception
            throw;
        }
    }
