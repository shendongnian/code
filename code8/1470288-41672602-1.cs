    public CloudBlockBlob Move(CloudBlockBlob srcBlob, CloudBlobContainer destContainer)
        {
            CloudBlockBlob destBlob;
            if (srcBlob == null)
            {
                throw new Exception("Source blob cannot be null.");
            }
            if (!destContainer.Exists())
            {
                throw new Exception("Destination container does not exist.");
            }
            //Copy source blob to destination container
            using (MemoryStream memoryStream = new MemoryStream())
            {
                srcBlob.DownloadToStream(memoryStream);
                destBlob = destContainer.GetBlockBlobReference(srcBlob.Name);
                destBlob.UploadFromStream(memoryStream);
            }
            //remove source blob after copy is done.
            srcBlob.Delete();
            return destBlob;
        }
