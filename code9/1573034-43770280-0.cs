    CloudBlobContainer blobContainer = GetContainer(documentsContainerName); // I created a GetContainer method get the container from azure
    IEnumerable<string> blobs = blobContainer.ListBlobs().Select(blob =>
    {
        // Conversion of IListBlobItem to CloudBlockBlob to gain access to the DownloadToStream method
        CloudBlockBlob blockBlob = (CloudBlockBlob)blob; 
    
        byte[] png = null; // Byte array for PNG after conversion
        
        using (MemoryStream blockBlobStream = new MemoryStream()) // displose of blockBlobStream
        using (MemoryStream pngStream = new MemoryStream()) // dispose of memory stream
        {
            blockBlob.DownloadToStream(blockBlobStream);
    
            Bitmap.FromStream(blockBlobStream)
                .Save(pngStream, ImageFormat.Png);
    
            png = pngStream.ToArray(); // Get all bytes from stream
        }
    
        return System.Convert.ToBase64String(png); // convert and return png byte array to base64
    });
