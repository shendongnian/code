        public async Task<CloudBlockBlob> Move(CloudBlockBlob srcBlob, CloudBlobContainer destContainer)
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
            string name = srcBlob.Uri.Segments.Last();
            destBlob = destContainer.GetBlockBlobReference(name);
            await destBlob.StartCopyAsync(srcBlob);
            //remove source blob after copy is done.
            srcBlob.Delete();
            return destBlob;
        }
		
