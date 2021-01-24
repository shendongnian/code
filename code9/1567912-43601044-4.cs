      [Route("api/serious/updtTM")]
        [HttpPost]
        public void updtTM([FromBody]file imagefile)
        {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("aaaaa");
                var client = storageAccount.CreateCloudBlobClient();
                var container = client.GetContainerReference("images");
    
                CloudBlockBlob blockBlobImage = container.GetBlockBlobReference(imagefile.filename);
                blockBlobImage.Properties.ContentType = imagefile.contentType;
                blockBlobImage.Metadata.Add("DateCreated", DateTime.UtcNow.ToLongDateString());
                blockBlobImage.Metadata.Add("TimeCreated", DateTime.UtcNow.ToLongTimeString());
    
                MemoryStream stream = new MemoryStream(imagefile.str)
                {
                    Position=0
                };
                blockBlobImage.UploadFromStreamAsync(stream);
            }
