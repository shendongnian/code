    private async Task Upload(string localPath, string remotePath)
    {
        const int ChunkSize = 4096 * 1024;
        using (var fileStream = File.Open(localPath, FileMode.Open))
        {
            if (fileStream.Length <= ChunkSize)
            {
                await this.client.Files.UploadAsync(remotePath, body: fileStream);
            }
            else
            {
                await this.ChunkUpload(remotePath, fileStream, (int)ChunkSize);
            }
        }
    }
    private async Task ChunkUpload(String path, FileStream stream, int chunkSize)
    {
        ulong numChunks = (ulong)Math.Ceiling((double)stream.Length / chunkSize);
        byte[] buffer = new byte[chunkSize];
        string sessionId = null;
        for (ulong idx = 0; idx < numChunks; idx++)
        {
            var byteRead = stream.Read(buffer, 0, chunkSize);
            using (var memStream = new MemoryStream(buffer, 0, byteRead))
            {
                if (idx == 0)
                {
                    var result = await this.client.Files.UploadSessionStartAsync(false, memStream);
                    sessionId = result.SessionId;
                }
                else
                {
                    var cursor = new UploadSessionCursor(sessionId, (ulong)chunkSize * idx);
                    if (idx == numChunks - 1)
                    {
                        FileMetadata fileMetadata = await this.client.Files.UploadSessionFinishAsync(cursor, new CommitInfo(path), memStream);
                        Console.WriteLine (fileMetadata.PathDisplay);
                    }
                    else
                    {
                        await this.client.Files.UploadSessionAppendV2Async(cursor, false, memStream);
                    }
                }
            }
        }
    }
    
