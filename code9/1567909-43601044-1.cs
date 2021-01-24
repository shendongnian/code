      [Route("api/serious/updtTM")]
        [HttpPost]
        public void updtTM([FromBody]file imagefile)
        {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=brandofirststorage;AccountKey=ANY6u+hxyTBd/dWkXt0vnI1QTs7JAevub+yG2mriW4f2PAaHC5KMWOUJ/kwVjK/DcCUlTs3jOV3oeJ4QvBcW2g==");
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
