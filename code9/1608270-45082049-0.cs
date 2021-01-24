    public async Task UploadChunksFromPathAsync(string path, long fileLength)
    {
        var cloudBlockBlob = CloudBlobContainer.GetBlockBlobReference(FileName);
    
    	const int blockSize = 256 * 1024;
    	var bytesToUpload = fileLength;
    	long bytesUploaded = 0;
    	long startPosition = 0;
    
    	var blockIds = new List<string>();
    	var index = 0;
    
    	do
    	{
    		var bytesToRead = Math.Min(blockSize, bytesToUpload);
    		var blobContents = new byte[bytesToRead];
    
    		using (var fs = new FileStream(path, FileMode.Open))
    		{
    			fs.Position = startPosition;
    			fs.Read(blobContents, 0, (int) bytesToRead);
    		}
    
    		var blockId = Convert.ToBase64String(Encoding.UTF8.GetBytes(index.ToString("d6")));
    
    		blockIds.Add(blockId);
    		await cloudBlockBlob.PutBlockAsync(blockId, new MemoryStream(blobContents), null);
    
    		bytesUploaded += bytesToRead;
    		bytesToUpload -= bytesToRead;
    		startPosition += bytesToRead;
    		index++;
    	} while (bytesToUpload > 0);
    
    	await cloudBlockBlob.PutBlockListAsync(blockIds);   
    }
